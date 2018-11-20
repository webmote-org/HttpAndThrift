/*----------------------------------------------------------------
 Copyright (C) 2018 上海科箭软件科技有限公司版权所有

 项目名称：SCM.Audit.Service
 文件名：  CommTools
 创建者：  grant(巩建春)
 CLR版本： 4.0.30319.42000
 时间：    2018/11/7 17:59:57

 功能描述：

----------------------------------------------------------------*/
using Quantum.FrameworkNetCore.AttributeEx;
using Quantum.FrameworkNetCore.DB.EFEx;
using Quantum.FrameworkNetCore.Protocol.RpcProtocol;
using Quantum.FrameworkNetCore.Rpc.Server;
using Quantum.FrameworkNetCore.UserSession;
using SCM.Audit.Model.ScmAudit;
using SCM.RpcProxy;
using SCM.RpcProxy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM.Audit.Service
{
    /// <summary>
    /// CommTools
    /// </summary>
    public class CommTools
    {
        public const string CT = "ee27c35e-f8f9-4619-aabf-3125e84bcf90";
        public static string WmsSysId = "wms";
        public static string AuditSysId="Audit";

        public static List<UserSysInfo> GetAppListFromBase(RpcContext Context, out StatusCode code)
        {
            code = StatusCode.OK;
            //Context.Args.ct = CT;
            //return SCMBaseServiceRpcProxyManager.Proxy.GetUserApp(new RpcProxy.Base.GetUserAppArgs(), out code, Context);
             var user = Context.GetUserContext();
             return user.GetSysInfo();
        }
        public static GetListWmsWareHousesResult GetListWmsWareHouses(RpcContext Context, out StatusCode code)
        {
            code = StatusCode.OK;
            Context.Args.ct = CT;
            return SCMBaseServiceRpcProxyManager.Proxy.GetListWmsWareHouses(new GetListWmsWareHousesArgs(), out code, Context);
        }

    }
}
