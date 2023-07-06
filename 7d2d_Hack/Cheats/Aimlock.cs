using System.Linq;
using Game7D2D.Attributes;
using Game7D2D.Class;
using Game7D2D.Utilities;
using UnityEngine;

namespace Game7D2D.Cheats
{
    [Comp]
    public class Aimlock : MonoBehaviour
    {
        public static bool Aiming = false;
        private EntityAlive aimtarget;

        void OnGUI()
        {
            if (Global.Settings.AimbotOptions.AimlockDrawFOV && Global.Settings.AimbotOptions.AimlockLimitFOV && Global.Settings.AimbotOptions.Aimlock)
                Tools.DrawCircle(Colors.GetColor("Aimlock_FOV_Circle"), new Vector2(Screen.width / 2, Screen.height / 2), Global.Settings.AimbotOptions.AimlockFOV);
        }

        void Update()
        {
            // Toggle aiming
            if (Global.Settings.AimbotOptions.Aimlock)
            {
                if (Input.GetKeyDown(Global.Settings.AimbotOptions.AimlockKey))
                    Aiming = true;
                if (Input.GetKeyUp(Global.Settings.AimbotOptions.AimlockKey))
                    Aiming = false;
            }
            else if (Aiming) // if aimlock was turned off and aiming was on
            {
                Aiming = false;
            }

            // Check if aimbot can target player
            if (Aiming)
            {
                int? fov = null;
                if (Global.Settings.AimbotOptions.AimlockFOV != 0)
                    fov = Global.Settings.AimbotOptions.AimlockFOV;
                EntityAlive t = Tools.GetNearestTarget(fov);
                if (t != null)
                {
                    Tools.AimAt(t);
                }
            }
        }

        public static void AimAssist()
        {
            //Aimbot is semi copy and pasted
            //float minDist = 9999f;
            float min3DDist = 9999f;
            Vector3 playerPos = Manager.eLocalPlayer.transform.position;

            Vector2 target = Vector2.zero;

            #region Animal COMMENTED
            //if (Global.Settings.AimbotOptions.HitAnimal)
            //{
            //    foreach (EntityAnimal animal in Manager.eAnimal)
            //    {
            //        if (animal && animal.IsAlive())
            //        {
            //            Vector3 lookAt = animal.emodel.GetHeadTransform().position;
            //            Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);

            //            // If they're outside of our FOV.
            //            if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > Manager.FOV)
            //                continue;

            //            if (IsOnScreen(w2s))
            //            {
            //                //float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));
            //                float distance3d = Vector3.Distance(lookAt, playerPos);
            //                if (distance3d < min3DDist)
            //                {
            //                    min3DDist = distance3d;
            //                    target = new Vector2(w2s.x, Screen.height - w2s.y);
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #region Player COMMENTED
            //if (Global.Settings.AimbotOptions.HitPLayer)
            //{
            //    foreach (EntityPlayer player in Manager.ePlayers)
            //    {
            //        if (player && player.IsAlive())
            //        {
            //            Vector3 lookAt = player.emodel.GetHeadTransform().position;
            //            Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);

            //            // If they're outside of our FOV.
            //            if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > Global.Settings.AimbotOptions.AimlockFOV)
            //                continue;

            //            if (IsOnScreen(w2s))
            //            {
            //                //float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));
            //                float distance3d = Vector3.Distance(lookAt, playerPos);
            //                if (distance3d < min3DDist)
            //                {
            //                    min3DDist = distance3d;
            //                    target = new Vector2(w2s.x, Screen.height - w2s.y);
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            if (Global.Settings.AimbotOptions.HitEnemy)
            {
                foreach (var eObj in ESP.EObjects.Where(x => x.Target == ESPObject.Enemy))
                {
                    EntityEnemy enemy = (EntityEnemy)eObj.Object;
                    if (enemy && enemy.IsAlive())
                    {
                        Vector3 lookAt = enemy.emodel.GetHeadTransform().position;
                        Vector3 w2s = Camera.main.WorldToScreenPoint(lookAt);

                        // If they're outside of our FOV.
                        if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2),
                                new Vector2(w2s.x, w2s.y)) > Global.Settings.AimbotOptions.AimlockFOV)
                            continue;

                        if (IsOnScreen(w2s))
                        {
                            //float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));
                            float distance3d = Vector3.Distance(lookAt, playerPos);
                            if (distance3d < min3DDist)
                            {
                                min3DDist = distance3d;
                                target = new Vector2(w2s.x, Screen.height - w2s.y);
                            }
                        }
                    }
                }
            }

            if (target != Vector2.zero)
            {
                double distX = target.x - Screen.width / 2f;
                double distY = target.y - Screen.height / 2f;
                if (Vector2.Distance(new Vector2((float)Screen.width / 2, (float)Screen.height / 2), new Vector2((float)distX, (float)distY)) <= 5f)
                {
                    distX /= 1;
                    distY /= 1;
                }
                else if (Vector2.Distance(new Vector2((float)Screen.width / 2, (float)Screen.height / 2), new Vector2((float)distX, (float)distY)) > 5f && Vector2.Distance(new Vector2((float)Screen.width / 2, (float)Screen.height / 2), new Vector2((float)distX, (float)distY)) < 20f)
                {
                    distX /= 2;
                    distY /= 2;
                }
                else
                {
                    distX /= 5;
                    distY /= 5;
                }
            }

        }

        public static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < Screen.height - 5f && position.z > 0.01f;
        }
    }
}
