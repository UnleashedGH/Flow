﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Xv2CoreLib.BCM
{
    #region Enums
    [Flags]
    public  enum ButtonInput : uint
    {
        None = 0,
      //[YAXEnum("Light")]
        Light = 1, //Square
                   //[YAXEnum("Heavy")]
        Heavy = 2, //Trianlge
                   //  [YAXEnum("Blast")]
        Kiblast = 4, //Circle
                   //  [YAXEnum("Jump")]
        Jump = 8, //X
                  // [YAXEnum("SkillMenu")]
        skillmenu = 16, //R2
                        // [YAXEnum("Boost")]
        Boost = 32, //L2
                    // [YAXEnum("Guard")]
        Guard = 64, //L1
                   // [YAXEnum("LockOn")]
        unk8 = 128,
        // [YAXEnum("SuperSkill1")]
        superskill1 = 256,
        //  [YAXEnum("SuperSkill2")]
        superskill2 = 512,
        // [YAXEnum("SuperSkill3")]
        superskill3 = 1024,
        //[YAXEnum("SuperSkill4")]
        superskill4 = 2048,
        // [YAXEnum("UltimateSkill1")]
        ultimateskill1 = 4096,
        // [YAXEnum("UltimateSkill2")]
        ultimateskill2 = 8192,
        //[YAXEnum("AwokenSkill")]
        awokenskill = 16384,
        // [YAXEnum("EvasiveSkill")]
        evasiveskill = 32768,
        // [YAXEnum("AdditionalInput")]
        additionalinput = 65536,
        //  [YAXEnum("SuperMenu_Duplicate")]
        supermenu_duplicate = 131072,
        // [YAXEnum("UltimateMenu")]
        ultimatemenu = 262144,
        unk20 = 524288,
        // [YAXEnum("LockOn")]
        lockon = 1048576, //unk21
                          // [YAXEnum("Descend")]
        descend = 2097152,
        // [YAXEnum("DragonRadar")]
        dragonradar = 4194304,
        unk24 = 8388608,
        unk25 = 16777216,
        unk26 = 33554432,
        unk27 = 67108864,
        unk28 = 134217728,
        //  [YAXEnum("UltimateMenu_Duplicate")]
        ultimatemenu_duplicate = 268435456,
        unk30 = 536870912,
        unk31 = 1073741824,
        unk32 = 2147483648
    }

    [Flags]
    public enum DirectionalInput : uint
    {
        // [YAXEnum("Forward")]
        forward = 1,
        // [YAXEnum("Backwards")]
        backwards = 2,
        // [YAXEnum("LeftRelative")]
        leftrelative = 4,
        // [YAXEnum("RightRelative")]
        rightrelative = 8,
        // [YAXEnum("SingleActivation")]
        singleactivation = 16,
        // [YAXEnum("Up")]
        up = 32,
        // [YAXEnum("Down")]
        down = 64,
        // [YAXEnum("Right")]
        right = 128,
        // [YAXEnum("Left")]
        left = 256,
        dirunk10 = 512,
        dirunk11 = 1024,
        dirunk12 = 2048,
        dirunk13 = 4096,
        dirunk14 = 8192,
        dirunk15 = 16384,
        dirunk16 = 32768,
        dirunk17 = 65536,
        dirunk18 = 131072,
        dirunk19 = 262144,
        dirunk20 = 524288,
        dirunk21 = 1048576,
        dirunk22 = 2097152,
        dirunk23 = 4194304,
        dirunk24 = 8388608,
        dirunk25 = 16777216,
        dirunk26 = 33554432,
        dirunk27 = 67108864,
        dirunk28 = 134217728,
        dirunk29 = 268435456,
        dirunk30 = 536870912,
        dirunk31 = 1073741824,
        dirunk32 = 2147483648
    }

    //ReciverLinkID
    [Flags]
    public enum BacCases
    {
        Case1 = 1,
        Case2 = 2,
        Case3 = 4,
        Case4 = 8,
        Case5 = 16,
        Case6 = 32,
        Case7 = 64,
        Case8 = 128,
    }

    [Flags]
    public enum ActivatorState : uint
    {
        //  [YAXEnum("Idle")]
        idle = 1,
        // [YAXEnum("Attacking")]
        attacking = 2,
        // [YAXEnum("Boosting")]
        boosting = 4,
        // [YAXEnum("Guarding")]
        guarding = 8,
        // [YAXEnum("ReceiveDamage")]
        receivedamage = 16,
        // [YAXEnum("Jumping")]
        jumping = 32,
        unk7 = 64,
        // [YAXEnum("TargetAttacking")]
        targetattacking = 128,
        unk9 = 256,
        unk10 = 512,
        unk11 = 1024,
        unk12 = 2048,
        unk13 = 4096,
        unk14 = 8192,
        unk15 = 16384,
        unk16 = 32768,
        unk17 = 65536,
        unk18 = 131072,
        unk19 = 262144,
        unk20 = 524288,
        unk21 = 1048576,
        unk22 = 2097152,
        unk23 = 4194304,
        unk24 = 8388608,
        unk25 = 16777216,
        unk26 = 33554432,
        unk27 = 67108864,
        unk28 = 134217728,
        unk29 = 268435456,
        unk30 = 536870912,
        unk31 = 1073741824,
        unk32 = 2147483648
    }

    public static class EnumValues
    {
       

        public static Dictionary<DirectionalInput, string> DirInput = new Dictionary<DirectionalInput, string>()
        {
            { DirectionalInput.forward , "Forward" },
            { DirectionalInput.backwards , "Backwards" },
            { DirectionalInput.leftrelative , "LeftRelative" },
            { DirectionalInput.rightrelative , "RightRelative" },
            { DirectionalInput.singleactivation , "SingleActivation" },
            { DirectionalInput.up , "Up" },
            { DirectionalInput.down , "Down" },
            { DirectionalInput.right , "Right" },
            { DirectionalInput.left , "Left" },
            { DirectionalInput.dirunk10 , "DirUnk10" },
            { DirectionalInput.dirunk11 , "DirUnk11" },
            { DirectionalInput.dirunk12 , "DirUnk12" },
            { DirectionalInput.dirunk13 , "DirUnk13" },
            { DirectionalInput.dirunk14 , "DirUnk14" },
            { DirectionalInput.dirunk15 , "DirUnk15" },
            { DirectionalInput.dirunk16 , "DirUnk16" },
            { DirectionalInput.dirunk17 , "DirUnk17" },
            { DirectionalInput.dirunk18 , "DirUnk18" },
            { DirectionalInput.dirunk19 , "DirUnk19" },
            { DirectionalInput.dirunk20 , "DirUnk20" },
            { DirectionalInput.dirunk21 , "DirUnk21" },
            { DirectionalInput.dirunk22 , "DirUnk22" },
            { DirectionalInput.dirunk23 , "DirUnk23" },
            { DirectionalInput.dirunk24 , "DirUnk24" },
            { DirectionalInput.dirunk25 , "DirUnk25" },
            { DirectionalInput.dirunk26 , "DirUnk26" },
            { DirectionalInput.dirunk27 , "DirUnk27" },
            { DirectionalInput.dirunk28 , "DirUnk28" },
            { DirectionalInput.dirunk29 , "DirUnk29" },
            { DirectionalInput.dirunk30 , "DirUnk30" },
            { DirectionalInput.dirunk31 , "DirUnk31" },
            { DirectionalInput.dirunk32 , "DirUnk32" },
         };

        public static Dictionary<ActivatorState, string> ActivatorStates = new Dictionary<ActivatorState, string>()
        {
            { ActivatorState.boosting , "Boosting" },
            { ActivatorState.guarding , "Guarding" },
            { ActivatorState.idle , "Idle" },
            { ActivatorState.jumping , "Jumping" },
            { ActivatorState.receivedamage , "ReceiveDamage" },
            { ActivatorState.unk7 , "Unk7" },
            { ActivatorState.attacking , "Attacking" },
            { ActivatorState.targetattacking , "TargetAttacking" },
            { ActivatorState.unk9 , "Unk9" },
            { ActivatorState.unk10 , "Unk10" },
            { ActivatorState.unk11 , "Unk11" },
            { ActivatorState.unk12 , "Unk12" },
            { ActivatorState.unk13 , "Unk13" },
            { ActivatorState.unk14 , "Unk14" },
            { ActivatorState.unk15 , "Unk15" },
            { ActivatorState.unk16 , "Unk16" },
            { ActivatorState.unk17 , "Unk17" },
            { ActivatorState.unk18 , "Unk18" },
            { ActivatorState.unk19 , "Unk19" },
            { ActivatorState.unk20 , "Unk20" },
            { ActivatorState.unk21 , "Unk21" },
            { ActivatorState.unk22 , "Unk22" },
            { ActivatorState.unk23 , "Unk23" },
            { ActivatorState.unk24 , "Unk24" },
            { ActivatorState.unk25 , "Unk25" },
            { ActivatorState.unk26 , "Unk26" },
            { ActivatorState.unk27 , "Unk27" },
            { ActivatorState.unk28 , "Unk28" },
            { ActivatorState.unk29 , "Unk29" },
            { ActivatorState.unk30 , "Unk30" },
            { ActivatorState.unk31 , "Unk31" },
            { ActivatorState.unk32 , "Unk32" },
         };

    }

    #endregion

    // [YAXSerializeAs("BCM")]
    public class BCM_File
    {
        // [YAXDontSerializeIfNull]
        // [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement, EachElementName = "BCMEntry")]
        public List<BCM_Entry> BCMEntries { get; set; } = new List<BCM_Entry>();

        public static BCM_File Load(string path)
        {
            if (Path.GetExtension(path) == ".bcm")
            {
                return new Parser(path, false).GetBcmFile();
            }
    
            else
            {
                return null;
            }
        }

        public static BCM_File Load(byte[] rawBytes)
        {
            return new Parser(rawBytes).bcmFile;
        }

        public void Save(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            new Deserializer(this, path);
        }

        public void IncreaseIds(int increaseAmount)
        {
            if (increaseAmount == 0) return;
            if (BCMEntries != null)
                IncreaseIds_Recursive(increaseAmount, BCMEntries);
        }

        private void IncreaseIds_Recursive(int increaseAmount, IList<BCM_Entry> entries)
        {
            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    entry.Index = (int.Parse(entry.Index) + increaseAmount).ToString();
                    IncreaseIds_Recursive(increaseAmount, entry.BCMEntries);
                }
            }
        }


    }

    // [YAXSerializeAs("BCMEntry")]
    [Serializable]
    public class BCM_Entry
    {
        //  [YAXAttributeForClass]
        // [YAXSerializeAs("Idx")]
        public string Index { get; set; }
        // [YAXAttributeForClass]
        // [YAXDontSerializeIfNull]
        //[YAXSerializeAs("Child_GoTo_Idx")]
        public string LoopAsChild { get; set; }
        //  [YAXAttributeForClass]
        //  [YAXDontSerializeIfNull]
        //  [YAXSerializeAs("Sibling_GoTo_Idx")]
        public string LoopAsSibling { get; set; }

        // [YAXAttributeFor("I_00")]
        // [YAXSerializeAs("value")]
        public UInt32 I_00 { get; set; }
        //  [YAXAttributeFor("DirectionalInput")]
        // [YAXSerializeAs("value")]
        public DirectionalInput I_04 { get; set; }
        // [YAXAttributeFor("ButtonInput")]
        // [YAXSerializeAs("value")]
        public uint I_08 { get; set; }
        // [YAXAttributeFor("HoldDownConditions")]
        // [YAXSerializeAs("value")]
        public UInt32 I_12 { get; set; }
        //[YAXAttributeFor("OpponentSizeConditions")]
        // [YAXSerializeAs("value")]
        public UInt32 I_16 { get; set; }
        // [YAXAttributeFor("MinimumLoopDuration")]
        // [YAXSerializeAs("value")]
        public UInt16 I_20 { get; set; }
        // [YAXAttributeFor("MaximumLoopDuration")]
        // [YAXSerializeAs("value")]
        public UInt16 I_22 { get; set; }
        // [YAXAttributeFor("PrimaryActivatorConditions")]
        // [YAXSerializeAs("value")]
        public UInt32 I_24 { get; set; }
        // [YAXAttributeFor("ActivatorState")]
        // [YAXSerializeAs("value")]
        public ActivatorState I_28 { get; set; }
        // [YAXAttributeFor("BacEntryPrimary")]
        // [YAXSerializeAs("value")]
        public Int16 I_32 { get; set; }
        // [YAXAttributeFor("BacEntryAirborne")]
        // [YAXSerializeAs("value")]
        public Int16 I_42 { get; set; }
        // [YAXAttributeFor("BacEntryCharge")]
        // [YAXSerializeAs("value")]
        public Int16 I_34 { get; set; }
        // [YAXAttributeFor("I_36")]
        // [YAXSerializeAs("value")]
        public Int16 I_36 { get; set; }
        // [YAXAttributeFor("BacEntryUserConnect")]
        // [YAXSerializeAs("value")]
        public Int16 I_38 { get; set; }
        // [YAXAttributeFor("BacEntryVictimConnect")]
        // [YAXSerializeAs("value")]
        public Int16 I_40 { get; set; }
        // [YAXAttributeFor("BacEntryUnknown")]
        // [YAXSerializeAs("value")]
        public UInt16 I_44 { get; set; }
        // [YAXAttributeFor("RandomFlag")]
        // [YAXSerializeAs("value")]
        public UInt16 I_46 { get; set; }

        // [YAXAttributeFor("sibling")]
        //[YAXSerializeAs("value")]
        public UInt32 I_48 { get; set; }

        // [YAXAttributeFor("child")]
        //[YAXSerializeAs("value")]
        public UInt32 I_52 { get; set; }

        // [YAXAttributeFor("parent")]
        //[YAXSerializeAs("value")]
        public UInt32 I_56 { get; set; }

        // [YAXAttributeFor("root")]
        //[YAXSerializeAs("value")]
        public UInt32 I_60 { get; set; }


        // [YAXAttributeFor("KiCost")]
        //[YAXSerializeAs("value")]
        public UInt32 I_64 { get; set; }
        //[YAXAttributeFor("I_68")]
        // [YAXSerializeAs("value")]
        public UInt32 I_68 { get; set; }
        // [YAXAttributeFor("I_72")]
        //  [YAXSerializeAs("value")]
        public UInt32 I_72 { get; set; }


        //  [YAXAttributeFor("Bac_Cases")]
        //  [YAXSerializeAs("values")]
        public BacCases I_76 { get; set; }

        // [YAXAttributeFor("I_80")]
        // [YAXSerializeAs("value")]
        public UInt32 I_80 { get; set; }
        // [YAXAttributeFor("StaminaCost")]
        // [YAXSerializeAs("value")]
        public UInt32 I_84 { get; set; }
        // [YAXAttributeFor("I_88")]
        // [YAXSerializeAs("value")]
        public UInt32 I_88 { get; set; }
        // [YAXAttributeFor("KiRequired")]
        // [YAXSerializeAs("value")]
        public UInt32 I_92 { get; set; }
        // [YAXAttributeFor("HealthRequired")]
        //[YAXFormat("0.0#######")]
        // [YAXSerializeAs("value")]
        public float F_96 { get; set; }
        //  [YAXAttributeFor("TransStage")]
        //  [YAXSerializeAs("value")]
        public Int16 I_100 { get; set; }
        // [YAXAttributeFor("CUS_AURA")]
        // [YAXSerializeAs("value")]
        public Int16 I_102 { get; set; }
        //[YAXAttributeFor("I_104")]
        // [YAXSerializeAs("value")]
        public UInt32 I_104 { get; set; }
        // [YAXAttributeFor("I_108")]
        // [YAXSerializeAs("value")]
        public UInt32 I_108 { get; set; }


        // [YAXDontSerializeIfNull]
        //  [YAXCollection(YAXCollectionSerializationTypes.RecursiveWithNoContainingElement, EachElementName = "BCMEntry")]
        public List<BCM_Entry> BCMEntries { get; set; }

        public BCM_Entry Clone()
        {
            return new BCM_Entry()
            {
                Index = Index,
                I_00 = I_00,
                I_04 = I_04,
                I_08 = I_08,
                I_100 = I_100,
                I_102 = I_102,
                I_104 = I_104,
                I_108 = I_108,
                I_12 = I_12,
                I_16 = I_16,
                I_20 = I_20,
                I_22 = I_22,
                I_24 = I_24,
                I_28 = I_28,
                I_32 = I_32,
                I_34 = I_34,
                I_36 = I_36,
                I_38 = I_38,
                I_40 = I_40,
                I_42 = I_42,
                I_44 = I_44,
                I_46 = I_46,
                I_64 = I_64,
                I_68 = I_68,
                I_72 = I_72,
                I_76 = I_76,
                I_80 = I_80,
                I_84 = I_84,
                I_88 = I_88,
                I_92 = I_92,
                F_96 = F_96
              
            };
        }
        public BCM_Entry Clone_WithChildEntries()
        {
            return new BCM_Entry()
            {
                Index = Index,
                I_00 = I_00,
                I_04 = I_04,
                I_08 = I_08,
                I_100 = I_100,
                I_102 = I_102,
                I_104 = I_104,
                I_108 = I_108,
                I_12 = I_12,
                I_16 = I_16,
                I_20 = I_20,
                I_22 = I_22,
                I_24 = I_24,
                I_28 = I_28,
                I_32 = I_32,
                I_34 = I_34,
                I_36 = I_36,
                I_38 = I_38,
                I_40 = I_40,
                I_42 = I_42,
                I_44 = I_44,
                I_46 = I_46,
                I_64 = I_64,
                I_68 = I_68,
                I_72 = I_72,
                I_76 = I_76,
                I_80 = I_80,
                I_84 = I_84,
                I_88 = I_88,
                I_92 = I_92,
                F_96 = F_96,
                BCMEntries = BCMEntries

            };
        }

        /// <summary>
        /// Checks to see if two entries are identical (excluding index and parent/children/siblings)
        /// </summary>
        /// <returns></returns>
        public bool Compare(BCM_Entry entry)
        {
            if (I_00 == entry.I_00 && I_04 == entry.I_04 &&  I_08 == entry.I_08 &&
                I_12 == entry.I_12 && I_16 == entry.I_16 &&
                I_20 == entry.I_20 && I_22 == entry.I_22 &&
                I_24 == entry.I_24 && I_28 == entry.I_28 &&
                I_32 == entry.I_32 && I_34 == entry.I_34 &&
                I_36 == entry.I_36 && I_38 == entry.I_38 &&
                I_40 == entry.I_40 && I_42 == entry.I_42 &&
                I_44 == entry.I_44 && I_46 == entry.I_46 &&
                I_64 == entry.I_64 && I_68 == entry.I_68 &&
                I_72 == entry.I_72 && I_80 == entry.I_80 &&
                I_84 == entry.I_84 && I_88 == entry.I_88 &&
                I_92 == entry.I_92 && I_100 == entry.I_100 && F_96 == entry.F_96 &&
                I_102 == entry.I_102 && I_104 == entry.I_104 &&
                I_108 == entry.I_108 && I_76 == entry.I_76
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + I_00.GetHashCode();
                hash = hash * 23 + I_04.GetHashCode();
                hash = hash * 23 + I_08.GetHashCode();
                hash = hash * 23 + I_100.GetHashCode();
                hash = hash * 23 + I_102.GetHashCode();
                hash = hash * 23 + I_104.GetHashCode();
                hash = hash * 23 + I_108.GetHashCode();
                hash = hash * 23 + I_12.GetHashCode();
                hash = hash * 23 + I_16.GetHashCode();
                hash = hash * 23 + I_20.GetHashCode();
                hash = hash * 23 + I_22.GetHashCode();
                hash = hash * 23 + I_24.GetHashCode();
                hash = hash * 23 + I_28.GetHashCode();
                hash = hash * 23 + I_32.GetHashCode();
                hash = hash * 23 + I_34.GetHashCode();
                hash = hash * 23 + I_36.GetHashCode();
                hash = hash * 23 + I_38.GetHashCode();
                hash = hash * 23 + I_40.GetHashCode();
                hash = hash * 23 + I_42.GetHashCode();
                hash = hash * 23 + I_44.GetHashCode();
                hash = hash * 23 + I_46.GetHashCode();
                hash = hash * 23 + I_64.GetHashCode();
                hash = hash * 23 + I_68.GetHashCode();
                hash = hash * 23 + I_72.GetHashCode();
                hash = hash * 23 + I_76.GetHashCode();
                hash = hash * 23 + I_80.GetHashCode();
                hash = hash * 23 + I_84.GetHashCode();
                hash = hash * 23 + I_88.GetHashCode();
                hash = hash * 23 + I_92.GetHashCode();
                hash = hash * 23 + F_96.GetHashCode();


                return hash;
            }
        }
    }


}
