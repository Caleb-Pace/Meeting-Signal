import sys

# Check argument count
args = len(sys.argv) - 1  # File is the first argument
if args != 2:
    if args > 2:
        raise Exception("Too many arguments supplied! (2 Required)")
    else:
        raise Exception("Not enough arguments supplied! (2 Required)")

print(str(int(sys.argv[1]) + int(sys.argv[2])))
