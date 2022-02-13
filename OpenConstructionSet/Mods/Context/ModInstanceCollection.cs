﻿namespace OpenConstructionSet.Mods.Context;

public class ModInstanceCollection : KeyedItemList<string, ModInstance>
{
    private readonly ModItem parent;

    internal ModInstanceCollection(ModItem parent, IEnumerable<IInstance> collection) : this(parent)
    {
        foreach (var item in collection)
        {
            AddFrom(item);
        }
    }

    internal ModInstanceCollection(ModItem parent)
    {
        this.parent = parent;
    }

    internal ModContext? Owner => parent.Owner;

    public override void Add(ModInstance item)
    {
        item.SetParent(this);
        base.Add(item);
    }

    public void Add(string id, string targetId, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, targetId, position, rotation, states));

    public void Add(string id, IItem target, Vector3 position, Vector4 rotation, IEnumerable<string> states)
        => Add(new(id, target.StringId, position, rotation, states));

    public void AddFrom(IInstance instance) => Add(instance is ModInstance mi ? mi : new ModInstance(instance));

    public IEnumerable<Instance> GetChanges(ModInstanceCollection baseInstances)
    {
        // All instances that are new (not in the baseInstances) or modified
        foreach (var instance in this.Where(instance => !baseInstances.TryGetValue(instance.Key, out var bi) || instance != bi)
                      .Select(instance => new Instance(instance)))
        {
            yield return instance;
        }

        // All instances that were deleted (not present in current instances)
        foreach (var instance in baseInstances.Where(i => !ContainsKey(i.Key)).Select(i => i.AsDeleted()))
        {
            yield return instance;
        }
    }
}