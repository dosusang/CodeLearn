using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public static class GameTools {

        public static Vector3[] DrawBezier(Vector3 p0, Vector3 p1, Vector3 p2, int size) {
            Vector3[] points = new Vector3[size+1];
            float t;
            for (int i = 0; i <= size; i++) {
                t = (float)i / (float)size;
                points[i] = (1 - t) * (1 - t) * p0 + 2 * t * (1 - t) * p1 + t * t * p2;
            }
            return points;
        }

        public static Vector3 GetCtrlPoint(Vector3 p0, Vector3 p1) {
            var p = (p0 + p1) / 2;
            p.x += 1;
            return p;
        }
    }
}

