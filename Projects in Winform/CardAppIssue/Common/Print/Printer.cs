using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Common.Print
{
    using EDI;

    public class Printer
    {
        public string PortNumber { get; set; }
        public string Port { get; set; }
        public string HardwareType { get; set; }
        public Printer()
        { }
        public Printer(string portNumber, string port, string hardwareType)
        {
            PortNumber = portNumber;
            Port = port;
            HardwareType = hardwareType;
        }

        public static List<Printer> GetPrinters()
        {
            string reply;
            var command = PrintCommand.QueryPrintersCommand();
            var sdk = new EdiSdkWrapper();
            sdk.CallFunc(ref command, out reply);

            XElement el;
            try
            {
                el = XElement.Parse(reply);
            }
            catch
            {
                return null;
            }

            var elPrinter = el.Element("printers");
            if (ReferenceEquals(elPrinter, null))
                return null;

            var rs = new List<Printer>();
            var nodes = elPrinter.Elements("printer");
            foreach (var n in nodes)
            {
                var pr = new Printer
                {
                    PortNumber = n.Attribute("port_number").Value,
                    Port = n.Attribute("port").Value,
                    HardwareType = n.Attribute("hardware_type").Value
                };
                rs.Add(pr);
            }

            return rs;
        }
        public string GetPrinterStatus()
        {
            string reply;
            var command = PrintCommand.PrinterStatusCommand(this);
            var sdk = new EdiSdkWrapper();
            sdk.CallFunc(ref command, out reply);

            XElement el;
            try
            {
                el = XElement.Parse(reply);
            }
            catch
            {
                return reply;
            }

            var state = reply;
            var elStatus = el.Element("status");
            if (!ReferenceEquals(elStatus, null))
                state = elStatus.Attribute("value").Value.ToSafeString();
            return state.ToLower();
        }
        //public string GetAllJobIds()
        //{
        //    string reply;
        //    var command = PrintCommand.QueryAllJobIdsCommand();
        //    var sdk = new EdiSdkWrapper();
        //    sdk.CallFunc(ref command, out reply);

        //    XElement el;
        //    try
        //    {
        //        el = XElement.Parse(reply);
        //    }
        //    catch
        //    {
        //        return reply;
        //    }

        //    var status = el.Attribute("accepted").Value.ToSafeString();
        //    if (status.ToLower() == "true")
        //    {
        //        var nodes = el.Elements("job_ids");
        //    }
        //    return status.ToLower();
        //}
        public string GetPrinterPosition()
        {
            string reply;
            var command = PrintCommand.PrinterStatusCommand(this);
            var sdk = new EdiSdkWrapper();
            sdk.CallFunc(ref command, out reply);

            XElement el;
            try
            {
                el = XElement.Parse(reply);
            }
            catch
            {
                return reply;
            }

            var state = String.Empty;
            var elStatus = el.Element("status");
            if (!ReferenceEquals(elStatus, null))
            {
                var elSubStatus = elStatus.Element("sub_status");
                if (!ReferenceEquals(elSubStatus, null))
                    state = elSubStatus.Attribute("value").ToSafeString();
            }
            return state.ToLower();
        }
        public string SetPrinterPosition(string pos)
        {
            string reply;
            var command = PrintCommand.PositionCardCommand(this, pos);
            var sdk = new EdiSdkWrapper();
            sdk.CallFunc(ref command, out reply);

            XElement el;
            try
            {
                el = XElement.Parse(reply);
            }
            catch
            {
                return reply;
            }

            var state = el.Attribute("accepted").Value.ToSafeString();
            return state.ToLower();
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", HardwareType, Port, PortNumber);
        }
    }
}
