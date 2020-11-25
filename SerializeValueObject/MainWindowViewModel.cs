using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.IO;
using System.Xml.Serialization;

namespace SerializeValueObject
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _myValueObject = new MyValueObject(0, "test");
            Id = _myValueObject.Id;
            Testo = _myValueObject.Testo;
        }
        private MyValueObject _myValueObject;


        private int _id; public int Id { get => _id; set { Set(() => Id, ref _id, value); } }
        private string _testo; public string Testo { get => _testo; set { Set(() => Testo, ref _testo, value); } }

        private int _deSerId; public int DeSerId { get => _deSerId; set { Set(() => DeSerId, ref _deSerId, value); } }
        private string _deSerTesto; public string DeSerTesto { get => _deSerTesto; set { Set(() => DeSerTesto, ref _deSerTesto, value); } }

        private string _xmlText; public string XmlText { get => _xmlText; set { Set(() => XmlText, ref _xmlText, value); } }

        private RelayCommand _serializeCmd;
        public RelayCommand SerializeCmd => _serializeCmd ?? (_serializeCmd = new RelayCommand(
            () => serialize(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));
        private void serialize()
        {
            MyValueObject newMyValueObject = new MyValueObject(Id, Testo);
            MyEntity myEntity = new MyEntity(newMyValueObject);

            XmlSerializer xmlSerializer = new XmlSerializer(myEntity.GetType());
            using (StringWriter textWriter = new StringWriter())
            {

                xmlSerializer.Serialize(textWriter, myEntity);
                XmlText = textWriter.ToString();
            }
        }


        private RelayCommand _deSerializeCmd;
        public RelayCommand DeSerializeCmd => _deSerializeCmd ?? (_deSerializeCmd = new RelayCommand(
            () => deSerialize(),
            () => { return 1 == 1; },
            keepTargetAlive: true
            ));
        private void deSerialize()
        {
            MyEntity myEntity = new MyEntity();
            XmlSerializer xmlSerializer = new XmlSerializer(myEntity.GetType());
            using (StringReader textReader = new StringReader(XmlText))
            {

                myEntity = (MyEntity)xmlSerializer.Deserialize(textReader);
                DeSerId = myEntity.MyValueObject.Id;
                DeSerTesto = myEntity.MyValueObject.Testo;
            }
        }


    }

}
