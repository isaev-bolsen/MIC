using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
    {
    class Program
        {
        static void Main(string[] args)
            {
            Un4seen.Bass.WAVEFORMATEX format = new Un4seen.Bass.WAVEFORMATEX(Un4seen.Bass.WAVEFormatTag.PCM, 1, 8000, 32, 0);
            Un4seen.Bass.Bass.BASS_Init(-1, format.nSamplesPerSec, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            MIC.MICClient MIC = new MIC.MICClient();
            int PlayStream = Un4seen.Bass.Bass.BASS_StreamCreate(format.nSamplesPerSec, format.nChannels, Un4seen.Bass.BASSFlag.BASS_SAMPLE_FLOAT, Un4seen.Bass.BASSStreamProc.STREAMPROC_PUSH);

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            System.IO.Stream stream = new System.IO.MemoryStream();

            for (int i=0 ;i<3;++i) //пробуем сначала наполнить поток со стороны клиента...
                {
                stream=MIC.GetData();
                float[] buf = (float[])(formatter.Deserialize(stream));
                Un4seen.Bass.Bass.BASS_StreamPutData(PlayStream, buf, buf.Length * 4);
                System.Threading.Thread.Sleep(500);
                }
            Un4seen.Bass.Bass.BASS_ChannelPlay(PlayStream, true);
            while (true)
                {
                stream = MIC.GetData();
                float[] buf = (float[])(formatter.Deserialize(stream));
                Un4seen.Bass.Bass.BASS_StreamPutData(PlayStream, buf, buf.Length * 4);
                //Un4seen.Bass.Bass.BASS_ChannelUpdate(PlayStream, buf.Length * 4);
                //Un4seen.Bass.Bass.BASS_ChannelSetPosition(PlayStream, -0.062);
                System.Threading.Thread.Sleep(500);
                }

            }
        }
    }
