#!/bin/bash
# Program:
#    This program shows "Hello World" in your screen.
#History

PATH=/bin:/sbin:/usr/bin:/usr/sbin:/usr/local/bin:/usr/local/sbin:~/bin
export PATH

sass style.scss style.css
cp style.css -t ../css -f
cp style.css.map -t ../css -f
rm style.css
rm style.css.map

exit 0
