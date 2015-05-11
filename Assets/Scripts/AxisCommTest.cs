using UnityEngine;
using System.Collections;

namespace Potion {
    public class AxisCommTest : MonoBehaviour {
		
        void Start()
        {
            var axisComm = new AxisCommunicator("https://api.andrewmcwatters.com/axis");
            axisComm.GetAccount("andrewmcwatters");
        }
    }
}