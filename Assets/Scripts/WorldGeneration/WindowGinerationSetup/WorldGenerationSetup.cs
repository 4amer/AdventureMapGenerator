using System;

[Serializable]
public class WorldGenerationSetup
{
    public string name { get; private set; }
    public int seed { get; private set; }
    public int zoomFloor { get; private set; }
    public int zoomDecoration { get; private set; }
    public int zoomBuildings { get; private set; }

    public WorldGenerationSetup(string name, int seed, int zoomFloor, int zoomDecoration, int zoomBuildings)
    {
        this.name = name;
        this.seed = seed;
        this.zoomFloor = zoomFloor;
        this.zoomDecoration = zoomDecoration;
        this.zoomBuildings = zoomBuildings;
    }

}
