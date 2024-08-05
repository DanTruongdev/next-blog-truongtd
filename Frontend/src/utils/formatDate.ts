const formatDate = (dateString: string): string => {
  let dateObj = new Date(dateString)
  let year = dateObj.getFullYear()
  let month = (dateObj.getMonth() + 1).toString().padStart(2, '0') // getMonth() is zero-based
  let day = dateObj.getDate().toString().padStart(2, '0')
  let formattedDate = `${year}-${month}-${day}`
  return formattedDate
}
export default formatDate
