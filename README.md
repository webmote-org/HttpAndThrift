# HttpAndThrift

# 1、Benchmark介绍
> wiki中有定义：基准测试是运行计算机程序，一组程序或其他操作的行为，以便评估对象的相对性能，通常是通过对其运行许多标准测试和试验。

目前许多成熟的github开源项目，均采用Benchmark测试结果作为性能依据。在 .net 代码世界中，当然是使用 [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)类库。
其支持 ：
- 编程环境 .NET Framework (4.6+), .NET Core (2.0+), Mono, CoreRT
- 支持语言: C#, F#, Visual Basic
- 操作系统: Windows, Linux, macOS
其可以方便的产生数据和图表
![在这里插入图片描述](https://img-blog.csdnimg.cn/20181120171751259.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlYm1vdGU=,size_16,color_FFFFFF,t_70)
# 2、测试下微服务访问效率
目前我司采用的是Thrift封装的微服务框架，而时常有声音想把它转为Http Api，其实也未尝不可，不过测试下性能指标，是不是更靠谱些。
说干就干。
因为只有.net core版本，因此其他版本忽略之。
//选择两组数据，1000次和10000次访问
```csharp
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
        //这是thrift rpc调用
        [Benchmark]
        public GetListWmsWareHousesResult RpcCall() => CommTools.GetListWmsWareHouses(new RpcContext(null,new Args<object>
        {
            tk= "04100ccc-0ac5-4ec7-ba53-9ad5fcfac2c4"
        }),out StatusCode code);
        //这是Http api调用
        [Benchmark]
        public Nullables ApiCall() => api.Call<Nullables,Nullables>("/mark/Test",new Nullables());
    }
```

# 3、结果
![在这里插入图片描述](https://img-blog.csdnimg.cn/20181120172405543.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlYm1vdGU=,size_16,color_FFFFFF,t_70)
**window平台下，仅有 10ms的差距，说明http api性能还是不错的！从最大值上看相差20ms。如果对性能要求较高，采用RPC是个不错的选择，毕竟查下数据库也不过几个ms甚至ns。**
****
 # 引用链接
1. [口袋代码仓库](http://codeex.cn)
2. [在线计算器](http://jisuanqi.codeex.cn)
3. 本节源码：[github](https://github.com/webmote-org/)

