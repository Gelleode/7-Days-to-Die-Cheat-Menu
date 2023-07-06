using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Cheats;
using Game7D2D.Class;
using Game7D2D.Menu;
using Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.Profiling;
using static UnityEngine.ParticleSystem;
using static UnityEngine.UI.CanvasScaler;

namespace Game7D2D.Utilities
{
    public class Tools
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public static Material DrawMaterial;

        public static string[] Characters =
        {
            "HD_Bob (Instance)",
            "HD_Joel (Instance)",
            "HD_Jen (Instance)",
            "HD_Rekt (Instance)",
            "HD_Hugh (Instance)",
            "HD_Hands_Male (Instance)",
            "HD_Hands_Female (Instance)",
            "HD_Crawler (Instance)",
            "demoZ (Instance)",
            "HD_RadZ_Radiated (Instance)",
            "HD_RadZ (Instance)",
            "HD_Screamer_Radiated (Instance)",
            "HD_Screamer (Instance)",
            "HD_Wight_Radiated (Instance)",
            "HD_Wight (Instance)",
            "HD_Soldier_Radiated (Instance)",
            "HD_Soldier (Instance)",
            "HD_Thug_Radiated (Instance)",
            "HD_Thug (Instance)",
            "HD_Cop_Radiated (Instance)",
            "HD_Cop (Instance)",
            "HD_Fat_Zombie_Radiated (Instance)",
            "HD_Fat_Zombie (Instance)",
            "HD_BigMomma_Radiated (Instance)",
            "HD_BigMomma (Instance)",
            "HD_LumberjackZ_Radiated (Instance)",
            "HD_LumberjackZ (Instance)",
            "HD_Biker_Radiated (Instance)",
            "HD_Biker (Instance)",
            "HD_WorkerZ_Radiated (Instance)",
            "HD_Worker (Instance)",
            "HD_YoRadiated (Instance)",
            "HD_Yo (Instance)",
            "HD_Darlene_Radiated (Instance)",
            "HD_Darlene (Instance)",
            "HD_Lab_Radiated (Instance)",
            "HD_Lab (Instance)",
            "HD_Moe_Radiated (Instance)",
            "HD_Moe (Instance)",
            "HD_Mechanic_Radiated (Instance)",
            "HD_MechanicZ (Instance)",
            "HD_Hazmat_Radiated (Instance)",
            "HD_HazmatZ (Instance)",
            "HD_Boe_Radiated (Instance)",
            "HD_Boe (Instance)",
            "HD_Spider_Radiated (Instance)",
            "HD_Spider (Instance)",
            "HD_Burnt_Zombie_Radiated (Instance)",
            "HD_Burnt_Zombie_Feral (Instance)",
            "HD_Burnt_Zombie (Instance)",
            "HD_SuitZ_Radiated (Instance)",
            "HD_SuitZ (Instance)",
            "HD_TomClark_Radiated (Instance)",
            "HD_TomClark (Instance)",
            "HD_Steve (Instance)",
            "HD_Steve_Radiated (Instance)",
            "HD_Steve (Instance)",
            "HD_Joe_Radiated (Instance)",
            "HD_Joe (Instance)",
            "HD_NurseZ_Radiated (Instance)",
            "HD_NurseZ (Instance)",
            "HD_Cocktail_Waitress_Radiated (Instance)",
            "HD_CocktailWaitress (Instance)",
            "HD_Marlene_Radiated (Instance)",
            "HD_Marlene (Instance)",
            "HD_Arlene_Radiated (Instance)",
            "HD_Arlene (Instance)"
        };
        private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;
        private static readonly GUIStyle textureStyle = new GUIStyle { normal = new GUIStyleState { background = backgroundTexture } };
        private static Vector3 eb_head, eb_neck, eb_spine, eb_leftshoulder, eb_leftarm, eb_leftforearm, eb_lefthand, eb_rightshoulder, eb_rightarm, eb_rightforearm;
        private static Vector3 eb_righthand, eb_hips, eb_leftupleg, eb_leftleg, eb_leftfoot, eb_rightupleg, eb_rightleg, eb_rightfoot;

        public static EntityAlive GetNearestTarget(int? pixelfov = null)
        {
            EntityAlive returnEntity = null;
            float min3DDist = 9999f;
            Vector3 playerPos = Manager.eLocalPlayer.transform.position;

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
                                new Vector2(w2s.x, w2s.y)) > pixelfov)
                            continue;

                        if (IsOnScreen(w2s))
                        {
                            //float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));
                            float distance3d = Vector3.Distance(lookAt, playerPos);
                            if (distance3d < min3DDist)
                            {
                                min3DDist = distance3d;
                                returnEntity = enemy;
                            }
                        }
                    }
                }
            }

            return returnEntity;
        }
        //Questionable
        public static bool IsOnScreen(Vector3 position) => position.y > 0.01f && position.y < Screen.height - 5f && position.z > 0.01f;
            //SHITTY
        public static void AimAt(EntityAlive target)
        {
            Vector3 w2s = Camera.main.WorldToScreenPoint(target.emodel.GetHeadTransform().position);
            Vector2 point = new Vector2(w2s.x, Screen.height - w2s.y);
            double distX = point.x - Screen.width / 2f;
            double distY = point.y - Screen.height / 2f;
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
            // Sadly not working :(
            //Debug.Log("Look At");
            //Manager.localP.entityPlayerLocal.cameraTransform.LookAt(target.transform);
            //Manager.localP.entityPlayerLocal.playerCamera.transform.LookAt(target.transform);
            //Manager.localP.entityPlayerLocal.finalCamera.transform.LookAt(target.transform);
            //Manager.localP.entityPlayerLocal.weaponCamera.transform.LookAt(target.transform);
            //Manager.localP.entityPlayerLocal.weaponCameraTransform.LookAt(target.transform);
            //Manager.localP.entityPlayerLocal.cameraTransform.LookAt(target.transform);
            //Global.MainCamera.transform.LookAt(target.transform);
            //Debug.Log("Looked At");
            mouse_event(0x0001, (int)distX, (int)distY, 0, 0);
        }
        public static bool VisibleFromCamera(Entity entity)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = Camera.main.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = Camera.main.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, Manager.eLocalPlayer.transform.position);
            Vector3 w2s_test = Camera.main.WorldToScreenPoint(entity.emodel.GetHeadTransform().position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
                return true;
            return false;
        }
        public static bool InScreenView(Vector3 scrnpt)
        {
            if (scrnpt.z <= 0f || scrnpt.x <= 0f || scrnpt.x >= 1f || scrnpt.y <= 0f || scrnpt.y >= 1f)
                return false;

            return true;
        }

        public static void ApplyShader(Shader shader, GameObject pgo, Color32 VisibleColor, Color32 OccludedColor)
        {
            if (shader == null) return;

            Renderer[] rds = pgo.GetComponentsInChildren<Renderer>();

            for (int j = 0; j < rds.Length; j++)
            {
                Material[] materials = rds[j].materials;
                
                for (int k = 0; k < materials.Length; k++)
                {
                    if (materials[k].shader.name == "Particles/Standard Unlit" ||
                        materials[k].shader.name == "Game/Particles/Unlit" ||
                        materials[k].shader.name == "Particles/Blood_Particle")
                        continue;
                    if (shader.name != materials[k].shader.name)
                    {
                        Debug.Log($"{materials[k].name}");
                        Debug.Log($"{materials[k].shader.name}");
                    }

                    materials[k].shader = shader;
                    materials[k].SetColor("_ColorVisible", VisibleColor);
                    materials[k].SetColor("_ColorBehind", OccludedColor);
                }
            }
        }

        public static void RemoveShaders(GameObject pgo)
        {
            if (Shader.Find("Standard") == null) return;

            Renderer[] rds = pgo.GetComponentsInChildren<Renderer>();

            for (int j = 0; j < rds.Length; j++)
            {
                if (!(rds[j].material.shader != Shader.Find("Standard"))) continue;

                Material[] materials = rds[j].materials;

                for (int k = 0; k < materials.Length; k++)
                {
                    if (Characters.Contains(materials[k].name))
                    {
                        materials[k].shader = Shader.Find("Game/Character");
                        continue;
                    }

                    materials[k].shader = Shader.Find("Standard");
                }
            }
        }

        public static void DrawBones(EntityEnemy entity)
        {
            Transform[] entityBones = entity.GetComponentInChildren<SkinnedMeshRenderer>().bones;
            int canBone = 0;

            for (int j = 0; j < entityBones.Length; j++)
            {
                if (entityBones[j].name == "Head") { eb_head = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Head
                if (entityBones[j].name == "Neck") { eb_neck = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Neck
                if (entityBones[j].name == "Spine") { eb_spine = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Spine
                if (entityBones[j].name == "LeftShoulder") { eb_leftshoulder = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftShoulder
                if (entityBones[j].name == "LeftArm") { eb_leftarm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftArm
                if (entityBones[j].name == "LeftForeArm") { eb_leftforearm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftForeArm
                if (entityBones[j].name == "LeftHand") { eb_lefthand = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftHand
                if (entityBones[j].name == "RightShoulder") { eb_rightshoulder = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightShoulder
                if (entityBones[j].name == "RightArm") { eb_rightarm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightArm
                if (entityBones[j].name == "RightForeArm") { eb_rightforearm = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightForeArm
                if (entityBones[j].name == "RightHand") { eb_righthand = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightHand
                if (entityBones[j].name == "Hips") { eb_hips = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Hips
                if (entityBones[j].name == "LeftUpLeg") { eb_leftupleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftUpLeg
                if (entityBones[j].name == "LeftLeg") { eb_leftleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftLeg
                if (entityBones[j].name == "LeftFoot") { eb_leftfoot = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftFoot
                if (entityBones[j].name == "RightUpLeg") { eb_rightupleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightUpLeg
                if (entityBones[j].name == "RightLeg") { eb_rightleg = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightLeg
                if (entityBones[j].name == "RightFoot") { eb_rightfoot = Camera.main.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightFoot
            }

            if (canBone >= 18)
            {
                DrawESPLine(eb_head, eb_neck, Color.green);
                DrawESPLine(eb_neck, eb_spine, Color.green);
                DrawESPLine(eb_spine, eb_hips, Color.green);

                DrawESPLine(eb_hips, eb_leftupleg, Color.green);
                DrawESPLine(eb_leftupleg, eb_leftleg, Color.green);
                DrawESPLine(eb_leftleg, eb_leftfoot, Color.green);
                DrawESPLine(eb_hips, eb_rightupleg, Color.green);
                DrawESPLine(eb_rightupleg, eb_rightleg, Color.green);
                DrawESPLine(eb_rightleg, eb_rightfoot, Color.green);

                DrawESPLine(eb_neck, eb_leftshoulder, Color.green);
                DrawESPLine(eb_leftshoulder, eb_leftarm, Color.green);
                DrawESPLine(eb_leftarm, eb_leftforearm, Color.green);
                DrawESPLine(eb_leftforearm, eb_lefthand, Color.green);

                DrawESPLine(eb_neck, eb_rightshoulder, Color.green);
                DrawESPLine(eb_rightshoulder, eb_rightarm, Color.green);
                DrawESPLine(eb_rightarm, eb_rightforearm, Color.green);
                DrawESPLine(eb_rightforearm, eb_righthand, Color.green);
            }
        }

        public static void DrawCircle(Color Col, Vector2 Center, float Radius)
        {
            GL.PushMatrix();
            DrawMaterial.SetPass(0);
            GL.Begin(1);
            GL.Color(Col);
            for (float num = 0f; num < 6.28318548f; num += 0.05f)
            {
                GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
                GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * Radius + Center.x, Mathf.Sin(num + 0.05f) * Radius + Center.y));
            }
            GL.End();
            GL.PopMatrix();
        }
        public static void DrawSnapline(Vector3 worldpos, Color color)
        {
            Vector3 pos = Global.MainCamera.WorldToScreenPoint(worldpos);
            pos.y = Screen.height - pos.y;
            GL.PushMatrix();
            GL.Begin(1);
            DrawMaterial.SetPass(0);
            GL.Color(color);
            GL.Vertex3(Screen.width / 2, Screen.height, 0f);
            GL.Vertex3(pos.x, pos.y, 0f);
            GL.End();
            GL.PopMatrix();
        }
        private static void DrawESPLine(Vector3 pointA, Vector3 pointB, Color objColor)
        {
            DrawLine(new Vector2(pointA.x, (float)Screen.height - pointA.y), new Vector2(pointB.x, (float)Screen.height - pointB.y), objColor, 1);
        }

        // SHITTY LINE
        //public static Texture2D lineTex;
        //public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
        //{
        //    Matrix4x4 matrix = GUI.matrix;
        //    if (!lineTex)
        //        lineTex = new Texture2D(1, 1);

        //    Color color2 = GUI.color;
        //    GUI.color = color;
        //    float num = Vector3.Angle(pointB - pointA, Vector2.right);

        //    if (pointA.y > pointB.y)
        //        num = -num;

        //    GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
        //    GUIUtility.RotateAroundPivot(num, pointA);
        //    GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
        //    GUI.matrix = matrix;
        //    GUI.color = color2;
        //}

        public static void DrawLine(Vector3 start,Vector3 end, Color color, int thickness)
        {
            DrawMaterial.SetPass(0);
            if (thickness == 0)
            {
                return;
            }
            if (thickness == 1)
            {
                GL.Begin(1);
                GL.Color(color);
                GL.Vertex3(start.x, start.y, start.z);
                GL.Vertex3(end.x, end.y, end.z);
                GL.End();
                return;
            }
            if (thickness == 3)
            {
                GL.Begin(7);
                GL.Color(color);
                GL.Vertex3(0f, 0f, 0f);
                GL.Vertex3(1f, 1f, 0f);
                GL.Vertex3(0f, 1f, 0f);
                GL.End();
                return;
            }
            thickness /= 2;
            GL.Begin(7);
            GL.Color(color);
            GL.Vertex3(start.x - (float)thickness, start.y - (float)thickness, start.z - (float)thickness);
            GL.Vertex3(start.x + (float)thickness, start.y + (float)thickness, start.z + (float)thickness);
            GL.Vertex3(end.x + (float)thickness, end.y + (float)thickness, end.z + (float)thickness);
            GL.Vertex3(end.x - (float)thickness, end.y - (float)thickness, end.z - (float)thickness);
            GL.End();
        }

        public static void DrawESPLabel(Vector3 worldpos, Color textcolor, Color outlinecolor, string text, string outlinetext = null)
        {
            GUIContent content = new GUIContent(text);
            if (outlinetext == null) outlinetext = text;
            GUIContent content1 = new GUIContent(outlinetext);
            GUIStyle style = GUI.skin.label;
            style.alignment = TextAnchor.MiddleCenter;
            Vector2 size = style.CalcSize(content);
            Vector3 pos = Global.MainCamera.WorldToScreenPoint(worldpos);
            pos.y = Screen.height - pos.y;
            if (pos.z >= 0)
            {
                GUI.color = Color.black;
                GUI.Label(new Rect((pos.x - size.x / 2) + 1, pos.y + 1, size.x, size.y), content1);
                GUI.Label(new Rect((pos.x - size.x / 2) - 1, pos.y - 1, size.x, size.y), content1);
                GUI.Label(new Rect((pos.x - size.x / 2) + 1, pos.y - 1, size.x, size.y), content1);
                GUI.Label(new Rect((pos.x - size.x / 2) - 1, pos.y + 1, size.x, size.y), content1);
                GUI.color = textcolor;
                GUI.Label(new Rect(pos.x - size.x / 2, pos.y, size.x, size.y), content);
                GUI.color = Main.GUIColor;
            }
        }
        public static void Draw3DBox(Bounds b, Color color)
        {
            Vector3[] pts = new Vector3[8];
            pts[0] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[1] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[2] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[3] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
            pts[4] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
            pts[5] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
            pts[6] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
            pts[7] = Global.MainCamera.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));

            for (int i = 0; i < pts.Length; i++) pts[i].y = Screen.height - pts[i].y;

            GL.PushMatrix();
            GL.Begin(1);
            DrawMaterial.SetPass(0);
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Begin(1);
            DrawMaterial.SetPass(0);
            GL.Color(color);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);

            GL.End();
            GL.PopMatrix();
        }

        public static float GetDistance(Vector3 endpos)
        {
            return (float)System.Math.Round(Vector3.Distance(Manager.localP.entityPlayerLocal.transform.position, endpos));
        }
    }
}
