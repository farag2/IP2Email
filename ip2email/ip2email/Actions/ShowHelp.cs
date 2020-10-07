using System.Collections.Generic;
using IP2Email.Classes;
using IP2Email.Interfaces;

namespace IP2Email.Actions
{
    class ShowHelp : IArgsAction
    {
        public void Do(string internetIP, List<string> localIPs, ref AppExitCodes appExitCode, AppConfig appConfig)
        {
            throw new System.NotImplementedException();
        }
    }
}
