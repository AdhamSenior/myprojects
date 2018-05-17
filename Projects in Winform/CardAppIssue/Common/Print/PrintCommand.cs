using System;
using System.Text;

namespace Common.Print
{
    public class PrintCommand
    {
        public static string PrinterStatusCommand(Printer pr)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<command");
            sb.AppendLine("name=\"get_printer_status\">");
            sb.AppendLine(String.Format("<printer port_number=\"{0}\" port=\"{1}\" hardware_type=\"{2}\"/>", pr.PortNumber, pr.Port, pr.HardwareType));
            sb.AppendLine("</command>");
            return sb.ToString();
        }

        public static string PositionCardCommand(Printer pr, string position)
        {
            // PrintPosition
            // ContactlessEncoderPosition
            // RejectPosition
            var sb = new StringBuilder();
            sb.AppendLine("<command");
            sb.AppendLine("name=\"device_command\">");
            sb.Append(String.Format("<device_command name=\"position_card\" destination=\"{0}\" />", position));
            sb.AppendLine(String.Format("<printer port_number=\"{0}\" port=\"{1}\" hardware_type=\"{2}\"/>", pr.PortNumber, pr.Port, pr.HardwareType));
            sb.AppendLine("</command>");
            return sb.ToString();
        }

        public static string QueryPrintersCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<command");
            sb.AppendLine("name=\"query_printers_with_status\">");
            sb.AppendLine("</command>");
            return sb.ToString();
        }

        public static string QueryAllJobIdsCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<command");
            sb.AppendLine("name=\"query_all_job_ids\">");
            sb.AppendLine("</command>");
            return sb.ToString();
        }
    }
}
