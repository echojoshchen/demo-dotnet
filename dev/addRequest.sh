#!/bin/bash

# Get the directory path of the script
script_dir=$(dirname "$0")

# Read the contents of the file into a variable
file_path="$script_dir/items.json"
body=$(cat "$file_path")

# Send the HTTP request using curl
curl -X POST -H "Content-Type: application/json" -d "$body" http://localhost:5242/api/1.0/add-items
