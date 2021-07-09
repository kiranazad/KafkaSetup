# KafkaSetup
Setup Kafka in local
Install Java JDK (Goto Java SE download site @ http://www.oracle.com/technetwork/java/javase/downloads/index.html.)
Download the latest release(binary) from https://kafka.apache.org/downloads and un-tar it with below commands from command prompt.
                  > tar -xzf kafka_2.12-2.5.0.tgz
                  > cd kafka_2.12-2.5.0

Create data folder in the extracted folder and create kafka and zookeeper folders inside the data folder
change dataDir location in config\zookeeper.properties  to zookeeper folder
change logdirs location in config\server.properties to kafka folder
Download NSSM (Non-Sucking Service Manager)  which is used for installing the windows Service

                          https://nssm.cc/release/nssm-2.24.zip

Step 1: Install Zookeeper as Windows Service
Open Windows Command with Admin → Goto Unzip path of NSSM → Goto Win64 (in my case system is 64-bit) → Run the Command shown below
                        > \nssm-2.24\win64> nssm install "Kafka Zookeeper"

                        

        Set Application Path, Startup Directory and Arguments in my case:

          Application Path: D:\Kafka\kafka_2.13-2.7.0\bin\windows\zookeeper-server-start.bat
          Startup Directory: D:\Kafka\kafka_2.13-2.7.0\bin\windows
          Arguments:  D:\Kafka\kafka_2.13-2.7.0\config\zookeeper.properties
Step 2: Install Kafka Broker as Windows Service
              Open Windows Command with Admin → Goto Unzip path of NSSM → Goto Win64 (in my case system is 64-bit) → Run the Command shown below

                        > \nssm-2.24\win64> nssm install "Kafka Broker"

                        

        Set Application Path, Startup Directory and Arguments in my case:

          Application Path: D:\Kafka\kafka_2.13-2.7.0\bin\windows\kafka-server-start.bat
          Startup Directory: D:\Kafka\kafka_2.13-2.7.0\bin\windows
          Arguments:  D:\Kafka\kafka_2.13-2.7.0\config\server.properties
Step 3: Start the Both the Services "Kafka Zookeeper"  and "Kafka Broker"
           Goto → Run (Win + R) → type "services.msc" → press ok
              

              Note : Make sure both the services are running

Sample Example Using C# - Download both the solutions to Produce  and Consume, data sent as an object in between producer and consumer 

We can create the topics and subscribe the topics from the code 
