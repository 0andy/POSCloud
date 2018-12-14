using System;
using System.Collections.Generic;
using System.Text;

namespace HC.POSCloud.PosEnmus
{
    public enum EnableEnum
    {
        启用 = 1,
        禁用 = 0
    }

    public enum CigaretteGradeEnum
    {
        一类烟 = 1,
        二类烟 = 2,
        三类烟 = 3,
        四类烟 = 4,
        五类烟 = 5,
    }

    public enum UserTypeEnum
    {
        会员 = 1
    }

    public enum BindStatus
    {
        已绑定 = 1,
        未绑定 = 2
    }

    public enum IntegralEnum
    {
        购买商品 = 1,
        评价商品 = 2,
        抽奖消费 = 3
    }
}
