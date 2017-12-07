namespace BLForTankGame
{
    public partial class Tank : ITanks, IObservableTank // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        public enum Direction { Left, Right, Up, Down }
    }
}