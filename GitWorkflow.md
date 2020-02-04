# Git Workflow

To make a branch:
 - Create and checkout to a branch

    `git checkout -b branch_name`
    
 - Push your branch onto the remote repo

    `git push origin branch_name`
1. Pull the latest code from the master branch and resolve any merge conflicts
    
    `git pull origin master`
    
2. Make your changes

3. Add and commit
    
    `git add <filename>` or `git add *` to add everything

    `git status` (check which files you have staged)

    `git commit -m “commit message”`

4. Pull the latest code from the master branch and resolve any merge conflicts
    
    `git pull origin master`
    
5. Push your branch onto your remote repo
    
    `git push origin branch_name`

To delete a branch:
 - `git branch -d branch_name`
 - `git push --delete origin branch_name`
