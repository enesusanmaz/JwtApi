using Me.Business.Abstract;
using Me.DataAccess.Abstract;
using Me.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Business.Concrete
{
    public class PhotoManager : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoManager(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public int Add(Photo item)
        {
           return _photoRepository.Add(item);
        }

        public IEnumerable<Photo> FindAll()
        {
            return _photoRepository.FindAll();
        }

        public Photo FindByID(int id)
        {
            return _photoRepository.FindByID(id);
        }

        public int Remove(int id)
        {
           return _photoRepository.Remove(id);
        }

        public int Update(Photo item)
        {
           return _photoRepository.Update(item);
        }
    }
}
