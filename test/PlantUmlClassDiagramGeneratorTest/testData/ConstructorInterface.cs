namespace PlantUmlClassDiagramGeneratorTest
{
    public interface IA
    {
        IA Merge(IA other);
    }
    public class ConstructorInterface
    {
        private readonly IA _iA;

        public ConstructorInterface(IA iA)
        {
            _iA = iA;
        }

        public IA Merging(IA other)
         => _iA.Merge(other);

    }
}