#!/bin/sh

ssh evgeny@10.128.0.31 /bin/bash <<EOF
  cd project
  cd coderoute
  git stash
  git pull origin dev
  git stash pop
  docker compose -f docker-compose-production.yaml up -d --no-deps --build backend
  docker compose -f docker-compose-production.yaml up -d --no-deps --build frontend
  exit
EOF
