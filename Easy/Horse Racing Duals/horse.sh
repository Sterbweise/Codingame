# Create the array of horse puissance
read -r N
for (( i=0; i<$N; i++ )); do
    read -r element
    P[$i]=$element
done

# Sort the array
P=($(for p in ${P[@]}; do echo $p; done | sort -n))

# Find the Minimum Distance
for (( i=1; i<$N; i++ )); do

    if (( $i==1 )); then
        D="$((${P[$i]}-${P[$i-1]}))"
    fi
    value="$((${P[$i]}-${P[$i-1]}))"
    if [ ${value#-} -lt $D ]; then
        D=$value
    fi
done 
echo $D