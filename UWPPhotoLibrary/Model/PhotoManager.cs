﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public static class PhotoManager
    {
        public static ObservableCollection<Photo> GetAllPhotos()
        {
            //Empty list of type photo will get created in the line below and the list name is photos.
            var photos = new ObservableCollection<Photo>();
            var allPhotos = GetPhotos();            
            foreach (var photo in allPhotos)
            {
                photos.Add(photo);
            }
            return photos;
            //The above foreach can write like below(shortcut)
            //allPhotos.ForEach(photo => photos.Add(photo));
        }

        public static ObservableCollection<Album> GetAllAlbums()
        {
            //Empty list of type photo will get created in the line below and the list name is photos.
            var albums = new ObservableCollection<Album>();
            var allAlbums = GetAlbums();
            foreach (var album in allAlbums)
            {
                albums.Add(album);
            }
            return albums;
            //The above foreach can write like below(shortcut)
            //allPhotos.ForEach(photo => photos.Add(photo));
        }


        public static void GetPhotosByCategory(ObservableCollection<Photo> photos, AlbumName albumName)
        {
            var allPhotos = GetPhotos();
            var filteredPhotos = allPhotos.Where(photo => photo.AlbumName == albumName).ToList();
            photos.Clear();
            filteredPhotos.ForEach(photo => photos.Add(photo));
        }


        /*We will be using below GetPhotos method for many other methods in this class, 
        that is the reason we are making it private and not using the type ObservableCollection*/
        /* and also, in order to keep our code organized we have created the below private method.
        * If in future, if we want to make any changes in photos list, if we make the changes here, 
        * everywhere will get updated. If we use observable collection in the below method, 
        * in future, if we want to make any changes in photos list the code becomes messy. */
        private static List<Photo> GetPhotos() 
        {
            var photos = new List<Photo>();
            photos.Add(new Photo("Animals1", AlbumName.Animals));
            photos.Add(new Photo("Animals2", AlbumName.Animals));

            photos.Add(new Photo("Baby1", AlbumName.Babies));
            photos.Add(new Photo("Baby2", AlbumName.Babies));

            photos.Add(new Photo("Flowers1", AlbumName.Flowers));
            photos.Add(new Photo("Flowers1", AlbumName.Flowers));

            photos.Add(new Photo("Fruits1", AlbumName.Fruits));
            photos.Add(new Photo("Fruits2", AlbumName.Fruits));

            photos.Add(new Photo("Nature", AlbumName.Nature));            

            return photos;
        }


        private static List<Album> GetAlbums()
        {
            //animals Album
            var albums = new List<Album>();
            var a = new Album($"Assets/Album Icons/Animals-Icon.png", AlbumName.Animals);               
            var photos = new List<Photo>();
            photos.Add(new Photo("Animals1", AlbumName.Animals));
            photos.Add(new Photo("Animals2", AlbumName.Animals));
            a.AlbumListPhotos = photos;
            albums.Add(a);

            //Babies Album
            var b = new Album($"Assets/Album Icons/Babies-Icon.png", AlbumName.Babies);               
            var photos1 = new List<Photo>();
            photos1.Add(new Photo("Baby1", AlbumName.Babies));
            photos1.Add(new Photo("Baby2", AlbumName.Babies));
            b.AlbumListPhotos = photos1;
            albums.Add(b);

            //Flowers Album
            var f = new Album($"Assets/Album Icons/Flowers-Icon.png", AlbumName.Flowers);
            var photos2 = new List<Photo>();
            photos2.Add(new Photo("Flowers1", AlbumName.Flowers));
            photos2.Add(new Photo("Flowers1", AlbumName.Flowers));
            f.AlbumListPhotos = photos2;
            albums.Add(f);

            //Fruits Album
            var fr = new Album($"Assets/Album Icons/Fruits-Icon.png", AlbumName.Fruits);
            var photos3 = new List<Photo>();
            photos3.Add(new Photo("Fruits1", AlbumName.Fruits));
            photos3.Add(new Photo("Fruits2", AlbumName.Fruits));
            fr.AlbumListPhotos = photos3;
            albums.Add(fr);

            //Nature Album
            var n = new Album($"Assets/Album Icons/Nature-Icon.png", AlbumName.Nature);
            var photos4 = new List<Photo>();
            photos4.Add(new Photo("Nature", AlbumName.Nature));
            n.AlbumListPhotos = photos4;
            albums.Add(n);
            return albums;
        }
     
    }
}
