## Part 1

Before running the various exercises from previous assignments, I ran tcpdump listening on specific ports to capture traffic. For example, to listen for the weather client and server traffic:

`tcpdump port 5556 -w wuserver.pcap`

"port" indicates to listen at a particular port
"-w" is the flag to write to a file followed by the file name which is "wuserver.pcap"

For the taskworker, listening at mulitple ports is required as it is setup to recieve information from the ventilator at port 5557 and deliver information to the sink via port 5558. The following command is how I filtered the data:

`tcpdump port 5557 or port 5558 -w taskwork.pcap`

"or" will catch traffic from both ports


## Part 2

### Merging 

When wireshark is downloaded, various tools come with it such as mergecap. The following command was used to combine all pcap files:

`mergecap -F pcap -w full-take.pcap wuserver.pcap wuclient.pcap taskvent.pcap taskwork.pcap tasksink.pcap `

"-F" flag indicates the type of output file. In this instance, I chose pcap. The default is pcapng

"-w" indicates the output file. In this command, it is full-take.pcap


### Splitting

tcpdump's -r flag allows the user to read binary files. Therefore I used this along with some filters to split full-take.pcap into weather and task.

`tcpdump -r full-take.pcap port 5556 >> weather.pcap`
`tcpdump -r full-take.pcap port 5557 or port 5558 >> task.pcap`