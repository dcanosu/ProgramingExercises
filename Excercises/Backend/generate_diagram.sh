#!/bin/bash
# 1. Prepare environment
mkdir -p ./Diagrams
MASTER_FILE="./Diagrams/FullProject.puml"
REL_FILE="./Diagrams/relations.tmp"

# 2. Initialize master file with horizontal layout configuration
echo "@startuml" > "$MASTER_FILE"
echo "top to bottom direction" >> "$MASTER_FILE"
# echo "left to right direction" >> "$MASTER_FILE"

# --- ENGINEERING TRICK FOR SPACING ---
# nodesep controls horizontal distance between classes
echo "skinparam nodesep 150" >> "$MASTER_FILE"
# ranksep controls vertical distance between hierarchy levels
echo "skinparam ranksep 150" >> "$MASTER_FILE"
echo "skinparam classAttributeIconSize 0" >> "$MASTER_FILE"
echo "skinparam ClassMemberIconDisplay true" >> "$MASTER_FILE"
# -----------------------------------------------------------

# 3. Process C# files
for file in *.cs; do
    echo "Processing $file..."
    puml-gen "$file" "./Diagrams/temp.puml"
    
    CLASS_NAME=$(grep "class " "./Diagrams/temp.puml" | head -n 1 | sed 's/{//g')
    
    if [ ! -z "$CLASS_NAME" ]; then
        echo "$CLASS_NAME {" >> "$MASTER_FILE"
        echo "    -- Fields --" >> "$MASTER_FILE"
        grep "^[[:space:]]*- " "./Diagrams/temp.puml" | grep -v "(" | sed 's/ : [a-zA-Z0-9]*//g' >> "$MASTER_FILE"
        echo "    -- Properties --" >> "$MASTER_FILE"
        grep "^[[:space:]]*+ " "./Diagrams/temp.puml" | grep -v "(" | sed 's/ : [a-zA-Z0-9]*//g; s/ <<get>>//g; s/ <<set>>//g' >> "$MASTER_FILE"
        echo "    -- Methods --" >> "$MASTER_FILE"
        grep "(" "./Diagrams/temp.puml" | sed 's/([^)]*)/()/g' | sed 's/ : [a-zA-Z0-9]*//g; s/ <<override>>//g' >> "$MASTER_FILE"
        echo "}" >> "$MASTER_FILE"
    fi
    # Preserve inheritance relationships
    grep "<|--" "./Diagrams/temp.puml" >> "$REL_FILE"
done

# 4. Finalize
[ -f "$REL_FILE" ] && cat "$REL_FILE" | sort | uniq >> "$MASTER_FILE"
echo "@enduml" >> "$MASTER_FILE"

# 5. Output and Cleanup
cat "$MASTER_FILE" > FinalDiagram.puml
rm -rf ./Diagrams
mkdir -p ./Diagrams
mv FinalDiagram.puml ./Diagrams/FinalDiagram.puml
echo "Done! Vertical diagram and spacing in FinalDiagram.puml"
