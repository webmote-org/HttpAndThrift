using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Quantum.FrameworkNetCore.Config;
using Quantum.FrameworkNetCore.Protocol.RpcProtocol;
using Quantum.FrameworkNetCore.Rpc;
using Quantum.FrameworkNetCore.Rpc.Server;
using Quantum.FrameworkNetCore.Tools;
using Quantum.FrameworkNetCore.UserSession;
using SCM.RpcProxy;
using SCM.RpcProxy.Base;

namespace SCM.Audit.Service
{
    [CoreJob(baseline: true)]
    [RPlotExporter, RankColumn]
    public class TestAbc
    {
        [Params(1000, 10000)]
        public int N;


        private Qt2Api api = new Qt2Api(new UserContext
        {
            Token = "04100ccc-0ac5-4ec7-ba53-9ad5fcfac2c4"
        });
        [GlobalSetup]
        public void Setup()
        {
            ServerSetting.Initlize("abb", 1);
            SCMBaseServiceRpcProxyManager.Initlize();

        }

        [Benchmark]
        public GetListWmsWareHousesResult RpcCall() => CommTools.GetListWmsWareHouses(new RpcContext(null,new Args<object>
        {
            tk= "04100ccc-0ac5-4ec7-ba53-9ad5fcfac2c4"
        }),out StatusCode code);

        [Benchmark]
        public Nullables ApiCall() => api.Call<Nullables,Nullables>("/mark/Test",new Nullables());
    }
}
