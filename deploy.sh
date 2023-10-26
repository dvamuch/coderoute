#!/bin/sh

ssh -p 2425 root@10.0.2.15 /bin/bash <<EOF 
  sudo echo "New value"
  cd project1
  cd vue_example
  git add .
  git commit -m "Yes"
  git pull origin main
  exit
EOF
