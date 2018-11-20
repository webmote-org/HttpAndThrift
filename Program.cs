using System;
using System.Threading;
using BenchmarkDotNet.Running;
using Quantum.FrameworkNetCore.Config;
using Quantum.FrameworkNetCore.Protocol.RpcProtocol;
using Quantum.FrameworkNetCore.Rpc;
using Quantum.FrameworkNetCore.Rpc.Server;
using SCM.RpcProxy;

namespace SCM.Audit.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread.Sleep(2000);
            //RpcProxy.SCMBaseServiceRpcProxyManager.Initlize();
            //CommTools.GetListWmsWareHouses(new RpcContext(null, new Args<object>
            //{
            //    tk = "04100ccc-0ac5-4ec7-ba53-9ad5fcfac2c4"
            //}), out StatusCode code);
            var summary = BenchmarkRunner.Run<TestAbc>();

            Console.WriteLine("app end....!");
        }
    }
}
