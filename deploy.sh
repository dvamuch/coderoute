#!/bin/sh

ssh -p 2425 root@10.0.2.15 /bin/bash <<EOF 
  sudo echo "New value"
  cd frontend_projectv2
  cd coderoute
  git add .
  git commit -m "Local changes"
  git pull origin master
  npm run build
  cp -r dist/* /usr/share/nginx/html/domain/
  exit
EOF
