using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game7D2D.Class
{
    public enum MenuTab
    {
        Visuals,
        Aimbot,
        Misc,
        Perks,
        Settings
    }

    public enum MiscOptions
    {
        Admin,
        Helper
    }

    public enum AimbotOptions
    {
        Silent,
        Aimlock
    }

    public enum SettingsOptions
    {
        Colors,
        Keybinds
    }

    public enum TargetLimb
    {
        Head = 0,
        Neck = 1,
        Spine = 2,
        LeftShoulder = 3,
        LeftArm = 4,
        LeftForeArm = 5,
        LeftHand = 6,
        RightShoulder = 7,
        RightArm = 8,
        RightForeArm = 9,
        RightHand = 10,
        Hips = 11,
        LeftUpLeg = 12,
        LeftLeg = 13,
        LeftFoot = 14,
        RightUpLeg = 15,
        RightLegRightFoot = 16,
        Random
    }

    public enum ESPObject
    {
        Player,
        Enemy,
        Item,
        NPC,
        Animal
    }

    public enum PerkObject
    {
        Perception,
        Strength,
        Fortitude,
        Agility,
        Intellect,
        Perk_Books,
        Crafting_Skills
    }

    public enum ShaderType
    {
        Material,
        Flat,
        None
    }

}
