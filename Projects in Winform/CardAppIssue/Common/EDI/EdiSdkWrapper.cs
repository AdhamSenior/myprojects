using System.Runtime.InteropServices;

namespace Common.EDI
{
    public class EdiSdkWrapper
    {
        private readonly IPrnDrvServer _server = new CoCOMServerClass() as IPrnDrvServer;

        //----------------------------------------------------------------------
        // If pdSdk.dll is not registered we need these ComImports to make IPrnDrvServer and COMServerClass
        // available for compiling
        [ComImport, Guid("52759D4E-12F7-47A5-A7CE-387BFE7CBF38")]
        [TypeLibType(4288)]
        public interface IPrnDrvServer
        {
            [DispId(1)]
            int callFunc(ref string input, out string output);
        }

        [ComImport, Guid("A15B8FAF-D5D8-4552-BDFC-2F1B6A043E24")]
        public class CoCOMServerClass
        {
        }

        public int CallFunc(ref string xmlCommand, out string xmlCommandResult)
        {
            var result = _server.callFunc(ref xmlCommand, out xmlCommandResult);
            return result;
        }
    }
}
