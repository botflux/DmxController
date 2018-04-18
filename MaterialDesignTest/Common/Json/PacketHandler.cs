using DmxController.StoryBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VPackage.Json;

namespace DmxController.Common.Json
{
    public static class JsonHandler
    {
        

        public static string ConstructColorPacket (byte r, byte g, byte b, byte intensity,string target, int targetAddress)
        {
            return JSONSerializer.Serialize<ColorPacket>(new ColorPacket()
            {
                Holder = new ColorPacket.ColorHolder()
                {
                    R = r,
                    G = g,
                    B = b,
                    Intensity = intensity,
                    Target = target,
                    TargetAddress = targetAddress
                }
            });
        }

        public static string ConstructStoryBoardPacket(StoryBoardElement[] elements, string target, int targetAddress, string storyBoardName)
        {
            return JSONSerializer.Serialize<StoryBoardPacket>(new StoryBoardPacket()
            {
                Holder = new StoryBoardPacket.StoryBoardHolder()
                {
                    Name = storyBoardName,
                    Elements = StoryBoardElementToStoryBoardElementPacket(elements, target, targetAddress)
                }
            });
        }

        private static StoryBoardPacket.StoryBoardHolder.StoryBoardElementPacket[] StoryBoardElementToStoryBoardElementPacket (StoryBoardElement[] elements, string target, int targetAddress)
        {
            List<StoryBoardPacket.StoryBoardHolder.StoryBoardElementPacket> list = new List<StoryBoardPacket.StoryBoardHolder.StoryBoardElementPacket>();
            foreach (StoryBoardElement e in elements)
            {
                list.Add(new StoryBoardPacket.StoryBoardHolder.StoryBoardElementPacket()
                {
                    R = e.R,
                    G = e.G,
                    B = e.B,
                    Intensity = 255,
                    Target = target,
                    TargetAddress = targetAddress,
                    Time = (int)Math.Round(e.Time * 1000)
                });
            }

            return list.ToArray();
        }

        [DataContract]
        private class StoryBoardPacket
        {
            [DataMember (Name = "storyboard")]
            private StoryBoardHolder holder;

            public StoryBoardHolder Holder
            {
                get
                {
                    return holder;
                }

                set
                {
                    holder = value;
                }
            }

            [DataContract]
            public class StoryBoardHolder
            {

                [DataMember(Name = "name")]
                private string name;

                [DataMember(Name = "elements")]
                private StoryBoardElementPacket[] elements;

                public StoryBoardElementPacket[] Elements
                {
                    get
                    {
                        return elements;
                    }

                    set
                    {
                        elements = value;
                    }
                }

                public string Name
                {
                    get
                    {
                        return name;
                    }

                    set
                    {
                        name = value;
                    }
                }

                [DataContract]
                public class StoryBoardElementPacket
                {

                    [DataMember(Name = "target", Order = 1)]
                    private string target;
                    [DataMember(Name = "targetAddress", Order = 2)]
                    private int targetAddress;
                    [DataMember(Name = "red", Order = 3)]
                    private byte r;
                    [DataMember(Name = "green", Order = 4)]
                    private byte g;
                    [DataMember(Name = "blue", Order = 5)]
                    private byte b;
                    [DataMember(Name = "intensity", Order = 6)]
                    private byte intensity;
                    [DataMember(Name = "time", Order = 7)]
                    private int time;

                    public int TargetAddress
                    {
                        get
                        {
                            return targetAddress;
                        }

                        set
                        {
                            targetAddress = value;
                        }
                    }

                    public string Target
                    {
                        get
                        {
                            return target;
                        }

                        set
                        {
                            target = value;
                        }
                    }

                    public byte Intensity
                    {
                        get
                        {
                            return intensity;
                        }

                        set
                        {
                            intensity = value;
                        }
                    }

                    public byte B
                    {
                        get
                        {
                            return b;
                        }

                        set
                        {
                            b = value;
                        }
                    }

                    public byte G
                    {
                        get
                        {
                            return g;
                        }

                        set
                        {
                            g = value;
                        }
                    }

                    public byte R
                    {
                        get
                        {
                            return r;
                        }

                        set
                        {
                            r = value;
                        }
                    }

                    public int Time
                    {
                        get
                        {
                            return time;
                        }

                        set
                        {
                            time = value;
                        }
                    }
                }
            }

        }

        [DataContract]
        private class ColorPacket
        {
            [DataMember (Name = "couleur")]
            private ColorHolder holder;

            public ColorHolder Holder
            {
                get
                {
                    return holder;
                }

                set
                {
                    holder = value;
                }
            }

            [DataContract]
            public class ColorHolder
            {

                [DataMember(Name = "target", Order = 1)]
                private string target;
                [DataMember(Name = "targetAddress", Order = 2)]
                private int targetAddress;
                [DataMember(Name = "red", Order = 3)]
                private byte r;
                [DataMember(Name = "green", Order = 4)]
                private byte g;
                [DataMember(Name = "blue", Order = 5)]
                private byte b;
                [DataMember(Name = "intensity", Order = 6)]
                private byte intensity;

                public int TargetAddress
                {
                    get
                    {
                        return targetAddress;
                    }

                    set
                    {
                        targetAddress = value;
                    }
                }

                public string Target
                {
                    get
                    {
                        return target;
                    }

                    set
                    {
                        target = value;
                    }
                }

                public byte Intensity
                {
                    get
                    {
                        return intensity;
                    }

                    set
                    {
                        intensity = value;
                    }
                }

                public byte B
                {
                    get
                    {
                        return b;
                    }

                    set
                    {
                        b = value;
                    }
                }

                public byte G
                {
                    get
                    {
                        return g;
                    }

                    set
                    {
                        g = value;
                    }
                }

                public byte R
                {
                    get
                    {
                        return r;
                    }

                    set
                    {
                        r = value;
                    }
                }
            }
        }
    }
}
