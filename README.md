# 7ZVaultWF
a simple winforms application for using password-protected archives on-the-go.

## **this utility is mostly a demo - it may not be functional as-is on any given machine, and may destroy data in cases of malfunction. do not rely on this utility to protect critically-important backups.**

## how to use
### setup
1. create a 7zip archive with whatever files you want, and encrypt it with a password
2. rename the file to `data.7z` (optional, but highly recommended as the default filename is this)
3. place `data.7z` next to the executable for 7ZVaultWF
### opening your vault
1. open 7ZVaultWF
2. type in your password
3. click "Unlock"
4. your vault is de-compressed and written to your local machine in a temporary folder
5. click "Open" to open the folder your vault is now located
### modifying files
1. open your vault via the instructions above
2. do whatever changes you want - add files, remove them, update them, etc.
3.
### closing your vault
1. open 7ZVaultWF (if it was closed)
2. click "Lock"
3. your vault will be re-compressed and saved to the disk it was opened from

## for developers
### where's the actual 7-zip binary? i don't see it! / how do i know the provided 7-zip isn't poisoned? / how do i update the provided 7-zip?
the 7-zip binary is stored as a blob inside `WindowVault7z.resx`. you can replace this with a copy you sourced directly from a 7-zip install. you may extract the data using a utility like https://github.com/bmaupin/resx-extractor or https://github.com/soyersoyer/resx2files (this is not an endorsement of either utility nor their authors.) for your convienience, i copied the 7zip binary used for this program into the source tree.