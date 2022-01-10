using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Text;

using System.Windows.Forms;

// 필요한 class를 using 해주자

using LibUsbDotNet.DeviceNotify;

using LibUsbDotNet;

using LibUsbDotNet.Main;





namespace SensingWaterLeak

{

    public partial class MainLeakInfo : Form

    {
        //변수 선언
        public static IDeviceNotifier mUsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
        public static UsbDeviceFinder mUsbDeviceFinder;
        public static UsbDevice mUsbDevice;
        SerialPort mSerialPort;

        public MainLeakInfo()

        {

            InitializeComponent();

            //Device change listener

            mUsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;



        }



        private void btn_device_no_load_Click(object sender, EventArgs e)

        {

            loadUSB();

        }



        //USB 연결/해제시 호출됨

        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)

        {

            listBox.Items.Clear();

            listBox.Items.Add("type :" + e.EventType);

            listBox.Items.Add("Object :" + e.Object);

            listBox.Items.Add("port :" + e.Port);

            listBox.Items.Add("Volume :" + e.Volume);

            if (e.Device != null)

            {

                listBox.Items.Add("vID :" + e.Device.IdVendor);

                listBox.Items.Add("pID :" + e.Device.IdProduct);

                listBox.Items.Add("SerialNumber :" + e.Device.SerialNumber);

                listBox.Items.Add("SymbolicName :" + e.Device.SymbolicName);

                listBox.Items.Add("Name :" + e.Device.Name);

                listBox.Items.Add("ClassGuid :" + e.Device.ClassGuid);

            }

        }



        //USB device를 read 한다

        private void loadUSB()

        {

            try

            {

                //finder 방법은 시리얼, vendorID, productID 등의 여러가지 방법이 있다.

                mUsbDeviceFinder = new UsbDeviceFinder("0001");

                //mUsbDeviceFinder = new UsbDeviceFinder("a5dcbf10-6530-11d2-901f-00c04fb951ed");



                mUsbDevice = UsbDevice.OpenUsbDevice(mUsbDeviceFinder);



                if (mUsbDevice == null)

                {

                    listBox.Items.Add("device is null");

                    return;

                }



                IUsbDevice wholeUsbDevice = mUsbDevice as IUsbDevice;

                if (!ReferenceEquals(wholeUsbDevice, null))

                {

                    wholeUsbDevice.SetConfiguration(1);

                    wholeUsbDevice.ClaimInterface(0);

                }



                UsbEndpointReader reader = mUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);



            }

            catch (Exception e)

            {

                listBox.Items.Add(e.ToString());

            }



        }

    }

}