namespace BLForTankGame
{
    abstract partial class Cartridge : ICartridges // использовать паттерн "Цепочка обязанностей" (если он будет вообще нужен)
    {
        public enum TypeOfCartridges { Light, Medium, Heavy } // перечисляемый тип для типов снарядов, мне кажется надо будет здесь поправить дело с доступом
    }
}
