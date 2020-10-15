﻿using PingPong.KUKA;

namespace PingPong.Tasks {

    interface ITask {

        void CalculateTargetPosition(KUKARobot robot1, KUKARobot robot2);

    }
}