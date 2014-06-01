using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MIC
    {
    //класс, реализующий сервис.
    //создает канал BASS, связанный с микрофоном по умолчанию
    //каждые 500мс извлекает из него запись
    //по запросу клиента возвращает запись в виде  MemoryStream
    public class MIC : IMIC
        {
        private static Un4seen.Bass.WAVEFORMATEX format = new Un4seen.Bass.WAVEFORMATEX(Un4seen.Bass.WAVEFormatTag.PCM, 1, 8000, 32, 0);
        private static  int recordChannel;
        private static bool isLaunched = false;
        private static  float[] buff=new float[4096]; //полсекунды звука
        private static System.Timers.Timer timer = new System.Timers.Timer(500);

        private void init()
            {
            isLaunched = true;
                Un4seen.Bass.Bass.BASS_RecordInit(-1);
                recordChannel = Un4seen.Bass.Bass.BASS_RecordStart(format.nSamplesPerSec,format.nChannels,Un4seen.Bass.BASSFlag.BASS_SAMPLE_FLOAT,null,IntPtr.Zero);
                Un4seen.Bass.Bass.BASS_ChannelPlay(recordChannel,false);
                Un4seen.Bass.Bass.BASS_ChannelSetAttribute(recordChannel, Un4seen.Bass.BASSAttribute.BASS_ATTRIB_VOL, 120);
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {//запись 500мс звука в буффер
            lock(buff)  Un4seen.Bass.Bass.BASS_ChannelGetData(recordChannel, buff, buff.Length * 4);
            }
   

        public MIC()
            {
            if (!isLaunched) init();//однократная инициализация для всех экземпляров.
            }

         public System.IO.Stream GetData()
            {//контрактный метод.
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(); 
             var output =new System.IO.MemoryStream();
             formatter.Serialize(output,buff);
             output.Seek(0, System.IO.SeekOrigin.Begin);
             return output;
             }
        }
    }
