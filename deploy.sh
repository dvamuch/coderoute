#!/bin/sh

ssh -p 2425 root@10.0.2.15 /bin/bash <<EOF 
  sudo echo "New value"
  cd fronted_project
  cd coderoute
  git add .
  git commit -m "Local changes"
  git pull origin main
  exit
EOF
