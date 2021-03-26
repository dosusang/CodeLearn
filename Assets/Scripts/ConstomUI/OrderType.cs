using System;

namespace QFramework.Example {
    public enum OrderType  {
        NONE,
        MOVE_FORWARD,
        TRUN_LEFT,
        TURN_RIGHT,
        LOOP_MAIN,
        LOOP_TAIL,
    };

    public enum InfoTypes {
        Error,
        Wram,
        Info,
    };

    public enum ItemType {
        GRASS,
        ROCK,
        GEM,
        TREE,
    }

}