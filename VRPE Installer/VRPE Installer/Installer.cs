﻿using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace VRPE_Installer
{
    internal class Installer
    {
        public static async Task InstallRookie(string selectedPath, string ver, string fixPath)
        {
            var destinationFilePath = Path.GetFullPath($"{selectedPath}{fixPath}RSL.zip");
            var outputFolder = Path.GetFullPath($"{selectedPath}{fixPath}");
            try
            {
                // Log the path in which Rookie was last installed in.
                PathLogger.LogRookie(selectedPath, ver);
                // Extract the RSL.zip into the selected path.
                ZipFile.ExtractToDirectory(destinationFilePath, outputFolder);
                // Delete the RSL.zip file as it is no longer needed.
                File.Delete(destinationFilePath);
            }
            catch (Exception ex)
            {
                // Catch and show the user any exception that happens during the entire process
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.InstallError();
            }
        }

        public static async Task InstallShortcutMaker(string selectedPathShortcutMaker, string fixPath)
        {
            var destinationFilePath = Path.GetFullPath($"{selectedPathShortcutMaker}{fixPath}ShortcutMaker.zip");
            var outputFolder = Path.GetFullPath($"{selectedPathShortcutMaker}{fixPath}");
            try
            {
                // Extract the ShortcutMaker.zip into the selected path.
                ZipFile.ExtractToDirectory(destinationFilePath, outputFolder);
                // Delete the ShortcutMaker.zip file as it is no longer needed.
                File.Delete(destinationFilePath);
            }
            catch (Exception ex)
            {
                // Catch and show the user any exception that happens during the entire process
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.InstallError();
            }
        }

        public static async Task InstallVRPGUI(string selectedPathVRPGUI, string fixPath)
        {
            var destinationFilePathVRPGUI = Path.GetFullPath($"{selectedPathVRPGUI}{fixPath}VRPGUI.zip");
            var createFolderPathVRPGUI = Path.GetFullPath($"{selectedPathVRPGUI}{fixPath}VRP-GUI");
            try
            {
                // Log the Path in which VRPGUI was last installed in.
                PathLogger.LogVRPGUI(selectedPathVRPGUI, fixPath);
                // Create a VRP-GUI folder otherwise all the files would just be extracted into the selected folder.
                Directory.CreateDirectory($"{createFolderPathVRPGUI}");
                // Extract VRPGUI into the created VRP-GUI folder from above which is inside the selected path.
                ZipFile.ExtractToDirectory(destinationFilePathVRPGUI, createFolderPathVRPGUI);
                // Lastly delete the VRPGUI.zip
                File.Delete(destinationFilePathVRPGUI);
            }
            catch (Exception ex)
            {
                // Catch and show the user any exception that happens during the entire process
                MessageBoxes.exceptionMessage = ex.Message;
                MessageBoxes.InstallError();
            }
        }
    }
}