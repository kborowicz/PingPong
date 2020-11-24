﻿namespace PingPong {
    interface IDevice {

        ///<summary>
        ///Initializes device
        ///</summary>
        void Initialize();

        /// <summary>
        /// Uninitializes device
        /// </summary>
        void Uninitialize();

        /// <summary>
        /// Checks if device is initialized (ready to use)
        /// </summary>
        /// <returns>true if device is ready to use, false otherwise</returns>
        bool IsInitialized();

    }
}