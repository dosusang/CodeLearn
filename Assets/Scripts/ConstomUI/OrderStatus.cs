using System;

namespace QFramework.Example {
    public enum OrderStatus {
        IS_BASE = 0,
        IN_AIR = 1,
        IN_HOLDER = 2,
    };

    public enum OrderHolderStatus {
        NORMAL,//普通状态
        SP,//特殊状态 比如循环命令在寻找另一半
    }

    public enum OrderMoveDirect {
        DOWN = 1,
        UP = -1,
    }

}