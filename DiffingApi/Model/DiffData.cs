using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffingApi
{
    public class DiffData
    {
        public string Id { get; set; }
        public string LeftNode { get; set; }
        public string RightNode { get; set; }

		public DiffData(String id, String left, String right)
		{
			
			this.Id = id;
			this.LeftNode = left;
			this.RightNode = right;
		}

		/**
		 * Instantiates a new diff.
		 */
		public DiffData()
		{
		}

		/**
		 * Gets the id.
		 *
		 * @return the id
		 */
		public String getId()
		{
			return Id;
		}

		/**
		 * Sets the id.
		 *
		 * @param id the new id
		 */
		public void setId(String id)
		{
			this.Id = id;
		}

		/**
		 * Gets the left.
		 *
		 * @return the left
		 */
		public String getLeft()
		{
			return LeftNode;
		}

		/**
		 * Sets the left.
		 *
		 * @param left the new left
		 */
		public void setLeft(String left)
		{
			this.LeftNode = left;
		}

		/**
		 * Gets the right.
		 *
		 * @return the right
		 */
		public String getRight()
		{
			return RightNode;
		}

		/**
		 * Sets the right.
		 *
		 * @param right the new right
		 */
		public void setRight(String right)
		{
			this.RightNode = right;
		}

	}
}
