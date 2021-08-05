#! /bin/sh

pip install psycopg2-binary
pip install bottle==0.12.13
pip install redis==2.10.5
python -u sender.py