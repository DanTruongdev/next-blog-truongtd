import { toast } from 'react-toastify'
const displayToast = (type: string, content: string): void => {
  let configToast: any = {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: true,
    closeOnClick: true,
    pauseOnHover: false,
    draggable: true,
    progress: undefined,
    theme: 'light',
  }
  if (type === 'success') toast.success(content, configToast)
  if (type === 'error') toast.error(content, configToast)
}

export default displayToast
