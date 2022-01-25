using PenScan.Data;
using PenScan.Models;
using PenScan.Views.Projects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PenScan.ViewModels.Scan
{
    public class ScannerViewModel : BaseViewModel
    {
        private double _Ipprogres;
        private string _ProgresLabel;
        private int _projectId;
        private bool _scanbuttonvisibul = true;
        private bool _savebutton = true;
        private List<string> _Ipadressen = new List<string>();
        private ObservableCollection<ScanItem> _ScanItems = new ObservableCollection<ScanItem>();

        public bool ScanButtonvisibul
        {
            get { return _scanbuttonvisibul; }
            set
            {
                _scanbuttonvisibul = value;
                NotifyPropertyChanged("ScanButtonvisibul");
            }
        }
        public double Ipprogres
        {
            get { return _Ipprogres; }
            set
            {
                _Ipprogres = value;
                NotifyPropertyChanged("Ipprogres");
            }
        }
        public string ProgresLabel
        {
            get { return _ProgresLabel; }
            set
            {
                _ProgresLabel = value;
                NotifyPropertyChanged("ProgresLabel");
            }
        }
        public List<string> Ipadressen
        {
            get { return _Ipadressen; }
            set
            {
                _Ipadressen = value;
                NotifyPropertyChanged("Ipadressen");
            }
        }
        public ObservableCollection<ScanItem> ScanItems
        {
            get { return _ScanItems; }
            set
            {
                _ScanItems = value;
                NotifyPropertyChanged("ScanItems");
            }
        }

        public ScannerViewModel(int projectId)
        {
            _projectId = projectId;
            var scanlist = db().GetAllscanitemsbyIdAsync(projectId);
            if (scanlist.Count != 0 )
            {
                ScanButtonvisibul = false;
                _savebutton = false;
                ScanItems = new ObservableCollection<ScanItem>(scanlist as List<ScanItem>);
            }
        }

        public ICommand ScannerCommand => new Command(Scanner);
        public ICommand SaveCommand => new Command(Save);

        private async void Save()
        {
            if (ScanItems != null)
            {
                if (_savebutton)
                {
                    var id = db().InsertScanitemsAsync(ScanItems);
                    if (id != null)
                    {
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }
                else
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("geen scan gedaan", "er is helaas geen content gevonden voor de scan probeer het later opniew", "OK");
            }
        }

        private async void Scanner()
        {


            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.78",
                HostName = "marco",
                Port = 453,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId

            });
            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.226",
                HostName = "server",
                Port = 54,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId
            });
            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.226",
                HostName = "server",
                Port = 80,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId
            });
            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.6",
                HostName = "patrick",
                Port = 21,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId
            });
            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.6",
                HostName = "patrick",
                Port = 80,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId
            });
            ScanItems.Add(new ScanItem
            {
                Ipaddress = "192.168.1.1",
                HostName = "rosaline",
                Port = 21,
                State = "open",
                Protocol = "tcp",
                projectId = _projectId
            });

            Ipprogres += 1.00;
            ScanButtonvisibul = false;
            //IpScanner();
            //PortScanner();
        }

        //deze functie scant niets als het op de emulator gebeurt vanwegen het niet bestaand network
        private async void IpScanner()
        {
            ProgresLabel = "Scanning Ip's on network!!";
            try
            {
                for (int i = 1; i < 255; i++)
                {
                    Ping p = new Ping();
                    PingReply rep = await p.SendPingAsync("192.168.1." + i);
                    if (rep.Status == IPStatus.Success)
                    {
                        Ipadressen.Add("192.168.1." + i);
                    }
                    Ipprogres += 0.00392;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //deze functie scant niets als het op de emulator gebeurt vanwegen het niet bestaand network
        public async void PortScanner()
        {
            ProgresLabel = "Scanning ports on ip!!";

            double IpProgres = 1.0 / Ipadressen.Count;
            double portprogres = IpProgres / Ports.Count();
            foreach (var ipadres in Ipadressen)
            {

                
                foreach (var Port in Ports)
                {
                    using (TcpClient Scan = new TcpClient())
                    {
                        
                        string Hostname = "?";
                        try
                        {
                            IPEndPoint endPoint = (IPEndPoint)Scan.Client.RemoteEndPoint;
                            // .. or LocalEndPoint - depending on which end you want to identify

                            IPAddress ipAddress = endPoint.Address;

                            // get the hostname
                            IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                            Hostname = hostEntry.HostName;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                        try
                        {
                            Scan.Connect(ipadres, Port);

                            ScanItems.Add(new ScanItem{
                                Ipaddress = ipadres,
                                HostName = Hostname,
                                Port = Port,
                                State = "open",
                                Protocol ="tcp"
                            });
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        Ipprogres += portprogres;
                    }
                }
                Ipprogres += IpProgres;
            }
            
        }

        private static int[] Ports = new int[]
        {
            80,
            443,
            21,
            22,
            110,
            995,
            143,
            25,
            26,
            587,
            3306,
            2082,
            2083,
            2086,
            2087,
            2095,
            2096,
            2077,
            2078,
            8080,
            51372,
            31146,
            4145
        };

    }
}
