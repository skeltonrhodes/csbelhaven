#!/usr/bin/env bash

# cat results.txt | while read line; do
#     host $line >> forward.txt
# done

# cat forward.txt | while read line; do
#     echo $line | ggrep -oP '(\d{4,}).*' >> justip.txt
# done

# cat justip.txt | while read line; do
#     host $line >> reverse.txt
# done

# cat a.txt | while read line; do
#     host $line | ggrep -oP '(\d{3,}).*' | tee finalres.txt >> ip.txt
#     cat ip.txt | while read line; do
#         host $line >> finalres.txt
#     done
# done

# cat a.txt | while read line; do
#     echo $line >> finaltest.txt
#     host $line | tee -a finaltest.txt| ggrep -oP '(\d{3,}).*' | xargs -I{} host {} >> finaltest.txt
#     printf "\n" >> finaltest.txt
# done

cat results.txt | while read line; do
    echo $line >> final.txt
    host $line | tee -a final.txt| sed -n -e 's/^.*has.*address //p' | xargs -I{} host {} >> final.txt
    printf "\n" >> final.txt
done
