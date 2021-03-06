﻿using CRUD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTest.OneToMany
{
    /// <summary>
    /// Summary description for OneToManyTest
    /// </summary>
    [TestClass]
    public class OneToManyTest
    {


        #region "Add"
        /// <summary>
        /// 在内存中创建10本书，每本书10个书评，保存到数据库中
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void TestAddBooks()
        {

            using (var context = new MyDBContext())
            {
                List<Book> books = OneToManyHelper.CreateBooks(10, 10);
                context.Books.AddRange(books);
                int result = context.SaveChanges();
                Assert.IsTrue(result > 0);
            }

        }
        /// <summary>
        /// 给书添加书评
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void TestAddBookReviewToBooks()
        {
            using (var context = new MyDBContext())
            {
                Book firstBook =  context.Books.FirstOrDefault();
                int reviewCount = firstBook.BookReviews.Count;
                BookReview review = OneToManyHelper.CreateBookReview(firstBook);
                int result = context.SaveChanges();
                Assert.IsTrue(result > 0);

                //重新加载图书
                Book firstBookFromDB =  context.Books.FirstOrDefault();
                //书评数加一
                Assert.IsTrue(firstBookFromDB.BookReviews.Count == reviewCount + 1);
                //应该能找得到新加的书评
                BookReview newReview = firstBookFromDB.BookReviews.First(br => br.BookReviewId == review.BookReviewId);
                Assert.IsNotNull(newReview);

            }
        }


        #endregion

        #region "Delete"
        //删除整本书
        [TestMethod]
        public void TestDeleteBook()
        {
            using (var context = new MyDBContext())
            {
                Book firstBook =  context.Books.FirstOrDefault();
                if (firstBook != null)
                {
                    context.Books.Remove(firstBook);
                    int result = context.SaveChanges();
                    Assert.IsTrue(result > 0);
                    //确认书的记录己经被删除
                    Book bookFromDB =  context.Books.FirstOrDefault(b => b.BookId == firstBook.BookId);
                    Assert.IsNull(bookFromDB);
                    //确认相关书评己经被删除
                    var query = from review in context.BookReviews
                                where review.BookId == firstBook.BookId
                                select review;
                    Assert.IsTrue(query.Count() == 0);
                }

            }
        }

        //删除第一本书的第一个书评
        [TestMethod]
        public void TestDeleteFirstBookFirstBookReview()
        {
            using (var context = new MyDBContext())
            {
                int reviewCount = 0;
                Book firstBook =  context.Books.Include("BookReviews")
                    .FirstOrDefault();
                if (firstBook != null && firstBook.BookReviews.Count > 0)
                {
                    //删除第一条书评
                    BookReview firstBookReview = firstBook.BookReviews.FirstOrDefault();
                    reviewCount = firstBook.BookReviews.Count;
                    //从主对象的集合属性中移除（可选）
                    firstBook.BookReviews.Remove(firstBookReview);
                    
                    //从DbSet中移除
                    context.BookReviews.Remove(firstBookReview);
                    int result = context.SaveChanges();
                    Assert.IsTrue(result ==1);

                    //重新提取记录
                    Book bookFromDB =  context.Books.Include("BookReviews").FirstOrDefault(b => b.BookId == firstBook.BookId);
                    Assert.IsTrue(bookFromDB.BookReviews.Count() == reviewCount - 1);
                    //确认相关书评己经被删除
                    var query = from review in context.BookReviews
                                where review.BookReviewId == firstBookReview.BookReviewId
                                select review;
                    Assert.IsTrue(query.Count() == 0);

                }

            }
        }

        #endregion

        #region "Update"


        //更新单个图书信息(略）

        //更新单个书评信息（略）

        //将第一本书的第一个书评移动到第二本书
        [TestMethod]
        public void TestBookReviewMove()
        {
            using (var context = new MyDBContext())
            {
                //找到第一本和第二本书，把第一本书的第一条书评移给第二本书
                Book firstBook =  context.Books.Include("BookReviews").FirstOrDefault();
                Book secondBook = context.Books.Include("BookReviews").ToList().ElementAt(1);
                if (firstBook != null && firstBook.BookReviews.Count > 0)
                {
                    BookReview bookReview = firstBook.BookReviews.ElementAt(0);
                    OneToManyHelper.ShowBookReivew(bookReview);
                    //先从原对象集合中移除
                    firstBook.BookReviews.Remove(bookReview);
                    //再追加到新对象的集合中
                    secondBook.BookReviews.Add(bookReview);
                    int result = context.SaveChanges();
                    Assert.IsTrue(result > 0);
                    //重新提取书评
                    BookReview reviewFromDB =  context.BookReviews.FirstOrDefault(r => r.BookReviewId == bookReview.BookReviewId);
                    Assert.IsTrue(reviewFromDB.BookId == secondBook.BookId);
                    OneToManyHelper.ShowBookReivew(reviewFromDB);
                }

            }

        }


        #endregion

    }
}
