The purpose of this exercise was to use the domains provided to do forward and reverse DNS lookups of the domains.

## Obtaining domains from tsv
`cut -f2 domains.tsv >> results.txt`

The cut command outputs the second column from domains.tsv.
No delimeter is specified because tab is the default delimeter for cut.
`-f2` flag specifies the field number which is 2 in this case.
`>> results.txt` appends stdout to the results.txt file. If the file does not exist it will automatically create the file.

## Forward/Reverse DNS 
```
cat results.txt | while read line; do
    echo $line >> final.txt
    host $line | tee -a final.txt| sed -n -e 's/^.*has.*address //p' | xargs -I{} host {} >> final.txt
    printf "\n" >> final.txt
done
```
`cat results.txt | while read line; do` allows for bash commands to be executed on each line of a file
`echo $line >> final.txt` This prints the domain before the DNS lookups are done
`host $line` This is a forward DNS lookup
`tee -a final.txt` tee is letting the previous command go to stdout and to the specified file. The `-a` is telling the tee command to append the previous output to the specified file in stead of overwriting it.
`sed -n -e 's/^.*has.*address //p'` This sed command separates the ip addresses from the Forward DNS lookup so I can do a Reverse DNS query. Technically, sed is replacing everything before the IP address with nothing, however this is not a crucial detail.
`xargs -I {} host {} >> final.txt` takes the stdout from the previous command and allows me to use it for another command. In this case, I host the separated ip given to us by the sed command and append it to the same file as the Forward DNS query.
`printf "\n" >> final.txt` appends a newline to the end of the last query to make the end file more human readable
`done` signifies the end of the do/while loop