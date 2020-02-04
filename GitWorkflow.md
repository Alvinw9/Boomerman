# Git Workflow

1. Create and checkout to a branch

    `git checkout -b branch_name`
    
2. Push your branch onto the remote repo

    `git push origin branch_name`
    
3. Make your changes

4. Add and commit
    
    `git add <filename>` or `git add *` to add everything

    `git status` (check which files you have staged)

    `git commit -m “commit message”`

5. Pull the latest code from the master branch and resolve any merge conflicts
    
    `git pull origin master`
    
6. Push your branch onto your remote repo
    
    `git push origin branch_name`

To delete a branch:
 - `git branch -d branch_name`
 - `git push --delete origin branch_name`
