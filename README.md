# ProcessCLIer
CLI to view and stop unwanted processes.

## Usage

| Flag  | Flag (Alternative) | Mode               | Result                                   | Example                                     | 
|:-----:|:------------------:|:-------------------|:-----------------------------------------|:--------------------------------------------|
| `-i`  | `-interactive`     | Interactive mode   | Menu                                     | `> AppKill.exe -i`                          | 
| `-l`  | `-list`            | Listing mode       | Lists currently running processes        | `> AppKill.exe -l`<br/>`> AppKill.exe -il`  | 
| `-k`  | `-kill`            | Silent Kill mode   | Kills the provided list of process names | `> AppKill.exe -k spotify chrome`           |
