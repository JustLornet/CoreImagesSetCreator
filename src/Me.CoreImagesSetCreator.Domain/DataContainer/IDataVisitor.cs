namespace Me.CoreImagesSetCreator.Domain.DataContainer
{
    internal interface IDataVisitor
    {
        internal void Visit(DataContainerBase dataContainer);
    }
}